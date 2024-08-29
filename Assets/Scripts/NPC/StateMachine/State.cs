using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    public string Name;
    protected StateMachine StateMachine;
    public bool IsDone;
    public bool InUse;

    protected virtual void Start()
    {
        StateMachine = GetComponent<StateMachine>();
    }

    public abstract IEnumerator Enter();

    public abstract IEnumerator Exit();
}
