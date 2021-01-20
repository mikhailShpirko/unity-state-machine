/*
Source: https://github.com/mikhailShpirko/unity-state-machine
Component: Events/VoidEvent.cs

The definition of Unity Event without arguments for exposing in Editor

MIT License
Copyright (c) 2020 Mikhail Shpirko
*/
using System;
using UnityEngine.Events;

namespace Events
{
    [Serializable]
    public class VoidEvent : UnityEvent
    {
    }
}