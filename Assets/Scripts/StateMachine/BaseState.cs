using System;
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
