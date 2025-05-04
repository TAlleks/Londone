using UnityEngine;
using UnityEngine.AI;
public class AttackState : BaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("Entered Attack State");
        enemy.NavMeshAgent.isStopped = true;   
        
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        if (!enemy.IsInAttackRange())
        {
            enemy.SwitchState(enemy.chaseState);
        }

        if (!enemy.CanSeePlayer())
        {
            enemy.SwitchState(enemy.searchState);
        }

        
        Debug.Log("Attacking!");
    }

    public override void ExitState(EnemyStateManager enemy)
    {
        Debug.Log("Exited Attack State");
    }
}
