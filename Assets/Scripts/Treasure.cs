using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    public uint Gold;
    private Renderer _renderer;
    private Collider _collider;
    
    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _renderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Player"))
        {
            NPCController.Instance.StateMachine.TreasureState.AddGold(Gold);
            StartCoroutine(Restart());
        }
    }

    private IEnumerator Restart()
    {
        _renderer.enabled = false;
        _collider.enabled = false;

        yield return new WaitForSeconds(10);

        _renderer.enabled = true;
        _collider.enabled = true;
    }
}
