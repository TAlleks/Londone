using UnityEngine.AI;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    [SerializeField] public Animator animator;
    [SerializeField] Collider collider;
    [SerializeField] NavMeshAgent navMeshAgent;
    [SerializeField] Transform player;
    [SerializeField] float viewDistance = 10f;        
    [SerializeField] public float attackRange = 2f;        
    [SerializeField] float searchTime = 5f;          

    Transform target;

    BaseState currentState;

    public PatrolState patrolState = new PatrolState();
    public ChaseState chaseState = new ChaseState();
    public AttackState attackState = new AttackState();
    public SearchState searchState = new SearchState();
    public IdleState idleState = new IdleState();

    
    public NavMeshAgent NavMeshAgent { get { return navMeshAgent; } }
    public Transform Player { get { return player; } }
    public float ViewDistance { get { return viewDistance; } }
    public float AttackRange { get { return attackRange; } }
    public float SearchTime { get { return searchTime; } }


    public void SwitchState(BaseState newState)
    {
        if (currentState != null)
        {
            currentState.ExitState(this); 
        }
        currentState = newState;
        currentState.EnterState(this); 
    }

    public void Start()
    {
        GameObject searchPivot = new GameObject();
        SetDestination(player);
        SwitchState(idleState);
    }

    public void Update()
    {
        //Debug.Log($"что {target.position.ToString()} {currentState.ToString()} {CanSeePlayer()}");
        navMeshAgent.destination = target.position;
        currentState.UpdateState(this); 
        
    }

    public void SetSpeed(float newSpeed)
    {
        navMeshAgent.speed = newSpeed;
    }

    public void SetDestination(Transform destination)
    {
        target = destination;
    }

    public float DistanceToTarget()
    {
        return (transform.position - target.transform.position).magnitude;
    } //полсекунды, € спизжу кусок из своего кода

    public void Rotate()
    {
        if (navMeshAgent.enabled)
        {
            navMeshAgent.transform.LookAt(navMeshAgent.destination);
        }
    }
    public bool CanSeePlayer()
    {
        return DistanceToTarget() <= viewDistance;

        //if (player == null) return false;  
        //if (Vector3.Distance(transform.position, player.position) > viewDistance) return false;

        //Vector3 direction = player.position - transform.position;
        //RaycastHit hit;
        //if (Physics.Raycast(transform.position, direction, out hit, viewDistance))
        //{
        //    if (hit.transform == player)
        //    {
        //        return true;
        //    }
        //}
        //return false;
    }

    public bool IsInAttackRange()
    {
        if (player == null) return false;  
        return DistanceToTarget() <= attackRange;
    }



    void ConditionsforAttack()
    {
        if (currentState == attackState)
        {
            SwitchState(searchState);
        }
    } 

    void ConditionsforHandAttack(int isOff)
    {
        if (isOff == 0)
        {
            collider.enabled = false;
        }
        else { collider.enabled = true; }
    }
}
