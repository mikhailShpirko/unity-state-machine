using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DemoGamePlay
{
    public class TimeScale : MonoBehaviour
    {
        public void SetToNormal()
        {
            Time.timeScale = 1f;
        }

        public void Stop()
        {
            Time.timeScale = 0f;
        }
    }
}

