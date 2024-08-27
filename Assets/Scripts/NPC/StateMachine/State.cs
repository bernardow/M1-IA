using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    public bool IsDone;

    public abstract IEnumerator Enter();

    public abstract IEnumerator Exit();
}
