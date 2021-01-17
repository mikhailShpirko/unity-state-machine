using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DemoEnemy
{
    public class WayPoint : MonoBehaviour
    {
        [SerializeField]
        private WayPoint _nextWayPoint;

        public WayPoint NextWayPoint => _nextWayPoint;
        public Vector3 Position => transform.position;
    }
}

