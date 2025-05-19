using UnityEngine;
using UnityEngine.AI;
public class ChaseState : BaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("Entered Chase State");
        enemy.NavMeshAgent.speed = 3.5f;  
        enemy.NavMeshAgent.isStopped = false;
        enemy.animator.SetBool("isAgro", true);

    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        enemy.SetDestination(enemy.Player); 

        if (!enemy.CanSeePlayer())
        {
            enemy.SwitchState(enemy.searchState);
        }

        if (enemy.IsInAttackRange())
        {
            enemy.SwitchState(enemy.attackState);
        }
    }

    public override void ExitState(EnemyStateManager enemy)
    {
        Debug.Log("Exited Chase State");
        enemy.NavMeshAgent.isStopped = true;
        //enemy.animator.SetBool("isAgro", false);

    }
}
