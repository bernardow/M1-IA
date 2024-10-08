using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public static NPCController Instance;

    public float Life = 10;
    public const float TotalLife = 10;
    public float Damage = 4;
    
    public StateMachine StateMachine;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        StateMachine.RunStateMachine();
    }

}
