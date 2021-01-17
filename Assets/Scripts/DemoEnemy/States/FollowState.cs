using StateMachine;
using UnityEngine;

namespace DemoEnemy.States
{
    public class FollowState : BaseState
    {
        [SerializeField]
        private EnemyVision _vision;
    
        private void Update()
        {
            if (_vision.HasTarget)
            {
                transform.position = Vector3.MoveTowards(transform.position, _vision.Target.position, Time.deltaTime * 3.5f);
            }
        }
    }

}
