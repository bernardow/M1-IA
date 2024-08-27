using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public override IEnumerator Enter()
    {
        throw new System.NotImplementedException();
    }

    public override IEnumerator Exit()
    {
        throw new System.NotImplementedException();
    }

    private void Update()
    {
        if (IsDone) return;

        Move();
    }

    private void Move()
    {

    }
}
