using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DemoGamePlay.Presenters
{
    public class ResumeCounterPresenter : MonoBehaviour
    {
        [SerializeField]
        private Text _counterText;

        public void UpdateCounterText(int currentValue)
        {
            _counterText.text = currentValue.ToString();
        }
    }
}
