using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureState : State
{
    private bool foundTreasure;
    
    public override IEnumerator Enter()
    {
        InUse = true;
        yield return new WaitForSeconds(StateMachine.MAX_TIME_IN_STATE);

        if (!foundTreasure)
        {
            IsDone = true;
            StateMachine.ChangeState(NPCStates.IDLE);
        }
        else
        {
            while (!IsDone)
                yield return null;

            StateMachine.ChangeState(NPCStates.IDLE);
        }
    }

    public override IEnumerator Exit()
    {
        yield return null;

        InUse = false;
        IsDone = false;
        foundTreasure = false;
    }

    private bool LookForTreasures(Collider other)
    {
        if (!other.CompareTag("Treasure")) return false;
        
        foundTreasure = true;
        return true;
    }

    private void MoveToTreasure(Vector3 treasurePosition)
    {
        transform.position += (treasurePosition - transform.position).normalized * 4 * Time.deltaTime;
    }

    public void AddGold(uint amount)
    {
        if (NPCController.Instance != null)
        {
            NPCController.Instance.Life += amount;
            Debug.Log($"NPC life: {NPCController.Instance.Life}");
            IsDone = true;
        }
    }

    private void OnTriggerStay(Collider other)
    { 
        if (!InUse) return;

        if (other.CompareTag("Enemy"))
        {
            StateMachine.ChangeState(NPCStates.IDLE);
            InUse = false;
            return;
        }
        
        if (LookForTreasures(other) && !IsDone)
        {
            MoveToTreasure(other.transform.position);
        }
    }
}
