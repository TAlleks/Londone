using UnityEngine;
using UnityEngine.AI;

public class SearchState : BaseState
{
    private float searchTimer = 0f;
    private Vector3 lastKnownPosition;

    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("Entered Search State");
        enemy.NavMeshAgent.speed = 1.5f; 
        enemy.NavMeshAgent.isStopped = false;
        searchTimer = 0f;
        lastKnownPosition = enemy.Player.position; 
        enemy.NavMeshAgent.SetDestination(lastKnownPosition);
        enemy.animator.SetBool("isAgro", true);
        enemy.animator.SetBool("isAttacking", false);
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        searchTimer += Time.deltaTime;

        if (enemy.CanSeePlayer())
        {
            enemy.SwitchState(enemy.chaseState);
        }

        if (searchTimer >= enemy.SearchTime)
        {
            enemy.SwitchState(enemy.idleState);
        }

        
    }

    public override void ExitState(EnemyStateManager enemy)
    {
        enemy.animator.SetBool("isAgro", false);
        Debug.Log("Exited Search State");
        enemy.NavMeshAgent.isStopped = true;
    }
}