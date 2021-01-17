using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DemoEnemy
{
    public class Player : MonoBehaviour
    {
        private void Update()
        {
            transform.Translate(GetMovementDirection());
        }

        private Vector3 GetMovementDirection()
        {
            return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Time.deltaTime * 4f;
        }
    }
}
