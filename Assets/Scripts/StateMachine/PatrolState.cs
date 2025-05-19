using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PatrolState : BaseState
{
    private int currentWaypointIndex = 0;
    private List<Transform> waypoints = new List<Transform>(); 

    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("Entered Patrol State");
        enemy.NavMeshAgent.speed = 2f; 
        enemy.NavMeshAgent.isStopped = false;

        // Найти все waypoints в сцене
        waypoints = new List<Transform>();
        Transform[] waypointsInScene = GameObject.FindGameObjectsWithTag("Waypoint").Select(go => go.transform).ToArray();
        if (waypointsInScene.Length > 0)
        {
            waypoints.AddRange(waypointsInScene);

            if (waypoints.Count > 0)
            {
                SetDestination(enemy); 
            }
            else
            {
                Debug.LogError("No waypoints found in the scene!");
            }
        }
        else
        {
            Debug.LogError("No waypoints found in the scene!");
        }
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        if (enemy.CanSeePlayer())
        {
            enemy.SwitchState(enemy.chaseState);
        }

        
        if (enemy.NavMeshAgent.remainingDistance <= enemy.NavMeshAgent.stoppingDistance && !enemy.NavMeshAgent.pathPending)
        {
            
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
            SetDestination(enemy);
        }
    }

    public override void ExitState(EnemyStateManager enemy)
    {
        Debug.Log("Exited Patrol State");
        enemy.NavMeshAgent.isStopped = true;
    }

    private void SetDestination(EnemyStateManager enemy)
    {
        if (waypoints.Count > 0)
        {
            var pos = waypoints[currentWaypointIndex];
            Debug.Log(pos.ToString());
            enemy.SetDestination(pos);
        }
    }
}
