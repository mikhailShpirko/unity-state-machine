using System;
using Events;
using UnityEngine;

namespace StateMachine
{
    public abstract class BaseState : MonoBehaviour
    {
        [SerializeField]
        private BaseState _nextState;
        
        [SerializeField]
        private VoidEvent _onEnter;
        
        [SerializeField]
        private VoidEvent _onExit;

        private void Awake()
        {
            //all states are disabled
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

        /// <summary>
        /// Transitions to next state
        /// </summary>
        /// <returns>State to which transition was done</returns>
        public BaseState Transition()
        {
            Disable();
            _onExit?.Invoke();
            _nextState?.Enter();
            return _nextState;
        }
    }
}
