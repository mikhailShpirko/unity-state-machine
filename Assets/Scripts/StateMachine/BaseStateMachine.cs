using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public class BaseStateMachine : MonoBehaviour
    {
        [SerializeField]
        [Header("Set initial state")]
        private BaseState _currentState;

        private void OnEnable()
        {
            //enter initial state when scene loaded 
            _currentState?.Enter();
        }

        public void Transition()
        {
            _currentState = _currentState?.Transition();
        }
    }
}
