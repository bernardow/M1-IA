using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    private int enemiesOnSight;
    private List<Collider> lastEnemiesSeen = new List<Collider>();
    
    public override IEnumerator Enter()
    {
        InUse = true;
        yield return new WaitForSeconds(StateMachine.MAX_TIME_IN_STATE);
        StateMachine.ChangeState(NPCStates.TREASURE);
    }

    public override IEnumerator Exit()
    {
        yield return null;

        enemiesOnSight = 0;
        lastEnemiesSeen.Clear();
        InUse = false;
        IsDone = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!InUse) return;
        
        if (other.CompareTag("Enemy"))
        {
            if (!lastEnemiesSeen.Contains(other))
            {
                enemiesOnSight++;
                lastEnemiesSeen.Add(other);
            }

            if (enemiesOnSight > 1 || NPCController.Instance.Life < NPCController.TotalLife * 0.5f)
                StateMachine.ChangeState(NPCStates.ESCAPING);
            else if (NPCController.Instance.Life >= NPCController.TotalLife * 0.5f) StateMachine.ChangeState(NPCStates.ATTACK);

            IsDone = true;
        }
    }
}
