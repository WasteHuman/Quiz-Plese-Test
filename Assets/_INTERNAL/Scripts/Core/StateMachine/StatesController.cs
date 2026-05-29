using Core.Base;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Core.StateMachine
{
    public class StatesController : IStateController<GameState>
    {
        private readonly Dictionary<GameState, IState> _states = new();

        private GameState? _targetState;
        private IState _currentState;

        public void RegisterState(GameState key, IState state) => _states[key] = state;

        public async UniTask EnterStateAsync(GameState state, CancellationToken ct)
        {
            if (_targetState == state)
            {
                Debug.LogWarning($"[StateController] Already transitioning to {state}, skipping");
                return;
            }

            _targetState = state;

            try
            {
                if (_currentState != null)
                    await _currentState.ExitAsync(ct);

                if (!_states.TryGetValue(state, out var nextState))
                {
                    Debug.LogError($"[StateController] State not found in dictionary: {state}");
                    return;
                }

                _currentState = nextState;

                await _currentState.EnterAsync(ct);
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"[StateController] Exception in EnterStateAsync: {ex}");
            }
            finally
            {
                _targetState = null;
            }
        }
    }
}