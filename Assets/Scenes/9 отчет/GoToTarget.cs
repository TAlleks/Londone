using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] NavMeshAgent navMeshAgent;
    [SerializeField] Transform player;

    [SerializeField] float stoppingDistance = 2f; // ƒистанци€, на которой враг останавливаетс€
    [SerializeField] float chaseSpeed = 3.5f;      // —корость преследовани€ игрока
    [SerializeField] float patrolSpeed = 1.5f;      // —корость патрулировани€

    private void Start()
    {
        navMeshAgent.stoppingDistance = stoppingDistance;
        navMeshAgent.speed = chaseSpeed; // устанавливаем скорость преследовани€
    }

    private void Update()
    {
        // ¬сегда преследуем игрока
        navMeshAgent.destination = player.position;

    }

   
}