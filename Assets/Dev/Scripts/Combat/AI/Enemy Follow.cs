using UnityEngine;
using UnityEngine.AI;
public class EnemyFollow : MonoBehaviour
{
    private Transform _player;
    private NavMeshAgent agent;
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
            _player = playerObj.transform;
        else
            Debug.LogError("Player not found! Make sure Player is tagged 'Player'.");
    }
    void Update()
    {
        if (_player != null)
        {
            agent.SetDestination(_player.position);
        }
    }

}
