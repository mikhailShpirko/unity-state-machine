using System.Collections;
using Events;
using StateMachine;
using UnityEngine;

namespace DemoGamePlay.States
{
    public class LoadingState : BaseState
    {
        [SerializeField]
        private VoidEvent _onLoaded;
        
        public void LoadResources()
        {
            StartCoroutine(LoadResourcesCoroutine());
        }

        private IEnumerator LoadResourcesCoroutine()
        {
            //assume that here is some code that loads resources
            yield return new WaitForSecondsRealtime(5f);
            _onLoaded?.Invoke();
        }
    }
}
