using System;
using System.Collections;
using System.Collections.Generic;
using NPC.StateMachine;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public const float MAX_TIME_IN_STATE = 5f;

    public IdleState IdleState;
    public TreasureState TreasureState;
    public AttackState AttackState;
    public EscapingState EscapingState;

    private State currentState;

    public void RunStateMachine()
    {
        ChangeState(NPCStates.IDLE);
    }

    public void ChangeState(NPCStates newState)
    {
        StartCoroutine(ChangeStateCoroutine(newState));
    }
    private IEnumerator ChangeStateCoroutine(NPCStates newState)
    {
        if (currentState != null)
            yield return StartCoroutine(currentState.Exit());

        currentState = newState switch
        {
            NPCStates.ATTACK => AttackState,
            NPCStates.ESCAPING => EscapingState,
            NPCStates.TREASURE => TreasureState,
            NPCStates.IDLE => IdleState,
            _ => IdleState
        };
        
        yield return StartCoroutine(currentState.Enter());
    }

    private void Update()
    {
        Debug.Log("Current State: " + currentState.Name);
    }
}
