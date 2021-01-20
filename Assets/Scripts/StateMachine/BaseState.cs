/*
Source: https://github.com/mikhailShpirko/unity-state-machine
Component: StateMachine/BaseState.cs

The abstraction for the states with core functionality: 
- enabling/disabling state
- events for State Entry and Exit

MIT License
Copyright (c) 2020 Mikhail Shpirko
*/
using Events;
using UnityEngine;

namespace StateMachine
{
    public abstract class BaseState : MonoBehaviour
    {
        [SerializeField]
        private VoidEvent _onEnter;
        
        [SerializeField]
        private VoidEvent _onExit;

        protected virtual void Awake()
        {
            //by default all states are disabled
            Disable();
        }

        private void Enable()
        {
            enabled = true;
        }
        
        private void Disable()
        {
            enabled = false;
        }
        
        /// <summary>
        /// Enter the state: enable component and trigger entry event
        /// Should be called when transitioned to it
        /// </summary>
        public void Enter()
        {
            Enable();
            _onEnter?.Invoke();
        }
        
        /// <summary>
        /// Exit the state: disable component and trigger exit event
        /// Should be called when transitioned from it
        /// </summary>
        public void Exit()
        {
            Disable();
            _onExit?.Invoke();
        }
    }
}
