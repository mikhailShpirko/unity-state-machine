using System;
using UnityEngine;

namespace DemoEnemy
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class EnemyColor : MonoBehaviour
    {
        [SerializeField]
        private Color _patrolColor = Color.blue;
        
        [SerializeField]
        private Color _followColor = Color.red;
        
        private SpriteRenderer _sprite;

        private void Awake()
        {
            _sprite = GetComponent<SpriteRenderer>();
        }

        private void SetColor(Color color)
        {
            _sprite.color = color;
        }

        public void SetPatrolColor()
        {
            SetColor(_patrolColor);
        }
        
        public void SetFollowColor()
        {
            SetColor(_followColor);
        }
    }
}

