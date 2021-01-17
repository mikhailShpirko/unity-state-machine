using System;
using UnityEngine.Events;

namespace DemoGamePlay
{
    
    //this event is not need for State Machine
    //and used only DemoGamePlay
    //so located here
    [Serializable]
    public class IntEvent : UnityEvent<int>
    {
    }
}