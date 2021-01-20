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
        
        public void Enter()
        {
            Enable();
            _onEnter?.Invoke();
        }

        public void Exit()
        {
            Disable();
            _onExit?.Invoke();
        }
    }
}
