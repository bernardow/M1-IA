using System.Collections;
using UnityEngine;

namespace NPC.StateMachine
{
    public class EscapingState : State
    {
        private Vector3 enemyPosition;
        
        public override IEnumerator Enter()
        {
            InUse = true;
            yield return new WaitForSeconds(global::StateMachine.MAX_TIME_IN_STATE);

            StateMachine.ChangeState(NPCStates.IDLE);
        }

        public override IEnumerator Exit()
        {
            yield return null;
            IsDone = false;
            InUse = false;
        }

        private void MovePlayer()
        {
            Vector3 direction = (transform.position - enemyPosition).normalized;
            transform.position += direction * 4 * Time.deltaTime;
        }

        private void OnTriggerStay(Collider other)
        {
            if (!InUse) return;
            
            if (other.CompareTag("Enemy"))
            {
                enemyPosition = other.transform.position;
                MovePlayer();
            }
        }
    }
}
