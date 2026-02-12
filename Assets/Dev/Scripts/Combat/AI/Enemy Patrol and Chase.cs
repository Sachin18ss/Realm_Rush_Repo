using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolAndChase : MonoBehaviour
{
    public float chaseRange = 10f;
    public PatrolPathSO patrolPath;

    private NavMeshAgent agent;
    private Transform[] patrolPoints;
    private Transform player;
    private int patrolIndex;
    private bool isChasing;
    private bool chaseAllowed = true;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        // Find player
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;

        // Resolve patrol points from scene
        if (patrolPath != null)
        {
            GameObject root = GameObject.Find(patrolPath.patrolArea);

            if (root != null)
            {
                patrolPoints = new Transform[root.transform.childCount];
                for (int i = 0; i < patrolPoints.Length; i++)
                    patrolPoints[i] = root.transform.GetChild(i);

                patrolIndex = Random.Range(0, patrolPoints.Length);
                GoToNextPatrolPoint();
            }
            else
            {
                Debug.LogError($"Patrol root not found: {patrolPath.patrolArea}");
            }
        }
    }

    private void Update()
    {
        if (player == null || patrolPoints == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= chaseRange && chaseAllowed)
            ChasePlayer();
        else
            Patrol();
    }

    void Patrol()
    {
        if (isChasing)
        {
            isChasing = false;
            GoToNextPatrolPoint();
        }

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GoToNextPatrolPoint();
    }

    void GoToNextPatrolPoint()
    {
        if (patrolPoints.Length == 0) return;

        int nextIndex;
        do
        {
            nextIndex = Random.Range(0, patrolPoints.Length);
        }
        while (nextIndex == patrolIndex);

        patrolIndex = nextIndex;

        agent.SetDestination(patrolPoints[patrolIndex].position);
        
    }

    void ChasePlayer()
    {
        isChasing = true;
        agent.SetDestination(player.position);
    }

    public void ForceReturnToPatrol()
    {
        isChasing = false;
        GoToNextPatrolPoint();
    }

    public void SetChaseAllowed(bool allowed)
    {
        chaseAllowed = allowed;

        if (!allowed)
            ForceReturnToPatrol();
    }
}
