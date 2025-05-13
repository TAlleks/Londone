using UnityEngine;

public class IdleState : BaseState
{
    private float _attackRange; // Добавляем переменную для хранения дальности атаки
    public override void EnterState(EnemyStateManager enemy) 
    {
        enemy.SetSpeed(0);
        _attackRange = enemy.attackRange;
        enemy.animator.SetBool("isAgro", false);
        enemy.animator.SetBool("isAttacking", false);
    }
    public override void UpdateState(EnemyStateManager enemy)
    {

        
        if (enemy.CanSeePlayer() && enemy.DistanceToTarget() < _attackRange)
        {
            enemy.SwitchState(enemy.attackState); // Переключаемся в состояние атаки
        }
        else if (enemy.CanSeePlayer())
        {
            enemy.SwitchState(enemy.chaseState);
        }
    }
    public override void ExitState(EnemyStateManager enemy) 
    { 

    
    }
}
