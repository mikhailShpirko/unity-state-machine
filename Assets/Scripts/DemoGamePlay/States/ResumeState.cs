using System.Collections;
using Events;
using StateMachine;
using UnityEngine;

namespace DemoGamePlay.States
{
    public class ResumeState : BaseState
    {
        [SerializeField]
        private IntEvent _onTick;

        [SerializeField]
        private VoidEvent _onDone;

        public void StartCountdown()
        {
            StartCoroutine(CountdownCoroutine());
        }

        private IEnumerator CountdownCoroutine()
        {
            for (var i = 3; i > 0; i--)
            {
                _onTick?.Invoke(i);
                yield return new WaitForSecondsRealtime(1f);
            }
            
            _onDone?.Invoke();
        }
    }
}

