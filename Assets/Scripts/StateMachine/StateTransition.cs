using System;
using UnityEngine;

namespace StateMachine
{
    [Serializable]
    public class StateTransition
    {
        [SerializeField]
        private BaseState _source;
        
        [SerializeField]
        private BaseState _destination;

        public BaseState Source => _source;
        public BaseState Destination => _destination;

        public bool IsSourceValid => _source != null;
        public bool IsDestinationValid => _source != _destination;

        public bool IsValid => IsSourceValid && IsDestinationValid;
    }
}

