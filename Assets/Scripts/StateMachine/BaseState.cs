using Unity.Mathematics.Geometry;
using UnityEngine;

// Базовый класс для состояний
public abstract class BaseState
{
    public abstract void EnterState(EnemyStateManager enemy);
    public abstract void UpdateState(EnemyStateManager enemy);
    public abstract void ExitState(EnemyStateManager enemy);
}