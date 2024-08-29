using System;
using System.Collections;
using System.Collections.Generic;
using Enemies;
using UnityEngine;

public class AttackState : State
{
    private bool finishedAttack;
    private Enemy enemy;
    private Vector3 enemyPosition;
    
    private int enemiesOnSight;
    private List<Collider> lastEnemiesSeen = new List<Collider>();
    
    public override IEnumerator Enter()
    {
        InUse = true;
        finishedAttack = false;
        enemyPosition = new Vector3();
        enemy = null;

        yield return null;
    }

    public override IEnumerator Exit()
    {
        yield return null;
        
        lastEnemiesSeen.Clear();
        enemiesOnSight = 0;
        enemy = null;
        IsDone = false;
        InUse = false;
    }

    private void MovePlayerToAttack()
    {
        float distance = Vector3.Distance(transform.position, enemyPosition);

        if (distance < 2 && !finishedAttack)
        {
            finishedAttack = true;
            Debug.Log($"Attacked {NPCController.Instance.Damage} damage and got {enemy.Damage} damage");
            NPCController.Instance.Life -= enemy.Damage;
            enemy.Life -= NPCController.Instance.Damage;

            if (NPCController.Instance.Life > NPCController.TotalLife * 0.5f)
                StateMachine.ChangeState(NPCStates.ATTACK);
            else StateMachine.ChangeState(NPCStates.ESCAPING);
            
            return;
        }

        transform.position += (enemyPosition - transform.position).normalized * 4 * Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!InUse) return;
        
        if (other.CompareTag("Enemy") && !finishedAttack)
        {
            if (!lastEnemiesSeen.Contains(other))
            {
                enemiesOnSight++;
                lastEnemiesSeen.Add(other);
            }
            
            if (enemy == null)
                enemy = other.GetComponent<Enemy>();
            
            enemyPosition = other.transform.position;
            if (enemiesOnSight == 1) MovePlayerToAttack();
        }
    }
}
