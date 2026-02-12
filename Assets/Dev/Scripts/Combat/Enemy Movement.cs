using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public EnemyMovementSO movementData;

    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    private void Update()
    {
        if (movementData == null) return;

        movementData.Move(transform, player);
    }
}
