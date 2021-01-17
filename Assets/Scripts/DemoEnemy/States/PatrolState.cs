using StateMachine;
using UnityEngine;

namespace DemoEnemy.States
{
    public class PatrolState : BaseState
    {
        [SerializeField]
        private WayPoint _currentWayPoint;
        
        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, _currentWayPoint.Position, Time.deltaTime * 2f);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<WayPoint>(out var wayPoint))
            {
                _currentWayPoint = wayPoint.NextWayPoint;
            }
        }
    }
}
