using Events;
using UnityEngine;

namespace DemoEnemy
{
    public class EnemyVision : MonoBehaviour
    {
        [SerializeField]
        private VoidEvent _onPlayerFound;

        [SerializeField]
        private VoidEvent _onPlayerLost;

        private Transform _target;

        public Transform Target => _target;

        public bool HasTarget => _target != null;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (IsTriggeredPlayer(other))
            {
                _target = other.transform;
                _onPlayerFound?.Invoke();
            }
        }
    
        private void OnTriggerExit2D(Collider2D other)
        {
            if (IsTriggeredPlayer(other))
            {
                _target = null;
                _onPlayerLost?.Invoke();
            }
        }

        private bool IsTriggeredPlayer(Collider2D other)
        {
            return other.TryGetComponent<Player>(out var player);
        }
    }
}
