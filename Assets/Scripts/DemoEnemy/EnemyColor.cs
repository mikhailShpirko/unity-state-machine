using System;
using UnityEngine;

namespace DemoEnemy
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class EnemyColor : MonoBehaviour
    {
        private SpriteRenderer _sprite;

        private void Awake()
        {
            _sprite = GetComponent<SpriteRenderer>();
        }

        public void SetPatrolColor()
        {
            _sprite.color = Color.blue;
        }
        
        public void SetFollowColor()
        {
            _sprite.color = Color.red;
        }
    }
}

