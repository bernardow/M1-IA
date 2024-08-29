using System;
using System.Collections;
using System.Collections.Generic;
using Enemies;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    public Enemy[] Enemies;

    public static EnemiesController Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }

        Destroy(gameObject);
    }

    public void ChangeMovementScript()
    {
        for (int i = 0; i < Enemies.Length; i++)
        {
            if (Enemies[i] != null && !Enemies[i].Dead)
            {
                Enemies[i].gameObject.AddComponent<PlayerMovement>();
                return;
            }
        }
    }
}
