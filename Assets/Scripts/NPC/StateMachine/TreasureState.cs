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

    public void AddGold(uint amount)
    {
        if (NPCController.Instance != null)
        {
            NPCController.Instance.GoldAmount += amount;
        }
    }
}
