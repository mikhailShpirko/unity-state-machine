using System;
using System.Reflection;
using System.Collections.Generic;
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
        
        public void Transition(BaseState nextState)
        {
            _currentState?.Exit();
            _currentState = nextState;
            _currentState?.Enter();
        }
    }
}
