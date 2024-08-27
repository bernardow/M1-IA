using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureState : State
{
    public override IEnumerator Enter()
    {
        throw new System.NotImplementedException();
    }

    public override IEnumerator Exit()
    {
        throw new System.NotImplementedException();
    }

    private bool LookForTreasures(Collider other)
    {
        if (other.CompareTag("Treasure"))
        {
            return true;
        }

        return false;
    }

    private void MoveToTreasure(Vector3 treasurePosition)
    {
        transform.position += ((treasurePosition - transform.position).normalized * 4) * Time.deltaTime;
    }

    public void AddGold(uint amount)
    {
        if (NPCController.Instance != null)
        {
            NPCController.Instance.GoldAmount += amount;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (LookForTreasures(other))
        {
            MoveToTreasure(other.transform.position);
            Debug.Log("inside");
        }
    }
}
