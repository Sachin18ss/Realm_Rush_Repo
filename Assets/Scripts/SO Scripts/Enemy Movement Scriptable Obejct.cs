using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Movement/Chase Player")]
public class EnemyMovementSO : ScriptableObject
{
    public float moveSpeed = 2f;
    public float chaseRange = 8f;
    public float stopDistance = 1.5f;

    public void Move(Transform enemy, Transform player)
    {
        if (player == null) return;

        float distance = Vector3.Distance(enemy.position, player.position);

        if (distance > chaseRange || distance <= stopDistance)
            return;

        Vector3 direction = (player.position - enemy.position).normalized;

        enemy.position += direction * moveSpeed * Time.deltaTime;

        // Face player (Y-axis only)
        direction.y = 0f;
        if (direction != Vector3.zero)
            enemy.rotation = Quaternion.LookRotation(direction);
    }
}
