using UnityEngine;
using UnityEngine.AI;
public class AttackState : BaseState
{
    
    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("Entered Attack State");
        enemy.NavMeshAgent.isStopped = true;
        //enemy.animator.SetBool("isAgro", false);
        enemy.animator.SetBool("isAttacking", true);

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
        enemy.animator.SetBool("isAttacking", false);

        Debug.Log("Exited Attack State");
    }

    
}
