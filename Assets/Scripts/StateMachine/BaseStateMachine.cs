/*
Source: https://github.com/mikhailShpirko/unity-state-machine
Component: StateMachine/BaseStateMachine.cs

The abstraction for the state machines with core functionality:
- storing of current active state
- transition from one state to another

MIT License
Copyright (c) 2020 Mikhail Shpirko
*/
using UnityEngine;

namespace StateMachine
{
    public class BaseStateMachine : MonoBehaviour
    {
        [SerializeField]
        [Header("Set initial state")]
        private BaseState _currentState;

        protected virtual void Awake()
        {
            _currentState?.Enter();
        }
        
        /// <summary>
        /// Transition from current state to next state provided as parameter
        /// </summary>
        /// <param name="nextState">State to be transitioned to</param>
        public void Transition(BaseState nextState)
        {
            _currentState?.Exit();
            _currentState = nextState;
            _currentState?.Enter();
        }
    }
}
