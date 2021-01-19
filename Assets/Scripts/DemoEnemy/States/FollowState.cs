using StateMachine;
using UnityEngine;

namespace DemoEnemy.States
{
    public class FollowState : BaseState
    {
        [SerializeField]
        private EnemyVision _vision;

        [SerializeField] 
        private float _followSpeed = 3.5f;
    
        private void Update()
        {
            if (_vision.HasTarget)
            {
                transform.position = Vector3.MoveTowards(transform.position, _vision.Target.position, Time.deltaTime * _followSpeed);
            }
        }
    }

}
