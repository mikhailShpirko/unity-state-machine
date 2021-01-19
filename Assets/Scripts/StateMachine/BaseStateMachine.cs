using System;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public class BaseStateMachine : MonoBehaviour
    {
        [SerializeField]
        [Header("Set initial state first, then define all other states with transition destinations")]
        private StateTransition[] _stateTransitions = new StateTransition[0];

        private readonly Dictionary<BaseState, BaseState> _stateTransitionDictionary = new Dictionary<BaseState, BaseState>();

        private BaseState _currentState;

        private void OnValidate()
        {
            if (_stateTransitions.Length == 0)
            {
                throw new ArgumentNullException("State Transitions", $"Define at least one state transition");
            }
            
            var states = new HashSet<BaseState>();
            for (var i = 0; i < _stateTransitions.Length; i++)
            {
                var paramName = $"State Transition {i}.Source";
                
                if (!_stateTransitions[i].IsSourceValid)
                {
                    throw new ArgumentNullException(paramName, $"Source in transition #{i} is not set");
                }
                
                if (!states.Add(_stateTransitions[i].Source))
                {
                    throw new ArgumentException($"Source in transition #{i} is already defined", paramName);
                }

                if (!_stateTransitions[i].IsDestinationValid)
                {
                    throw new ArgumentException($"Destination in transition #{i} can't be the same as Source", paramName);
                }
            }
            
            Debug.Log("State machine properly transitions set properly");
        }

        private void Start()
        {
            if (_stateTransitions.Length == 0)
            {
                return;
            }

            foreach (var transition in _stateTransitions)
            {
                if (!transition.IsValid)
                {
                    continue;
                }
                //disable all registered states
                transition.Source.Exit();
                transition.Destination?.Exit();
                if (!_stateTransitionDictionary.ContainsKey(transition.Source))
                {
                    _stateTransitionDictionary.Add(transition.Source, transition.Destination);
                }
            }

            _currentState = _stateTransitions[0].Source;
            _currentState.Enter();
        }


        public void Transition()
        {
            _currentState?.Exit();
            _currentState = _stateTransitionDictionary[_currentState];
            _currentState.Enter();
        }
    }
}
