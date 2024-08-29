using System;
using UnityEngine;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        public float Life;
        public readonly float Damage = 3;

        public bool Dead;
        
        private void Update()
        {
            if (Life <= 0)
            {
                Dead = true;
                Destroy(gameObject);
            }
        }

        private void OnDestroy()
        {
            EnemiesController.Instance.ChangeMovementScript();
        }
    }
}
