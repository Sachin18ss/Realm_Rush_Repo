using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnCenter;
    public float spawnRadius = 4f;

    public void SpawnEnemies(int count, PatrolPathSO patrolPath)
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 offset = Random.insideUnitSphere * spawnRadius;
            offset.y = 0f;

            GameObject enemyObj =
                Instantiate(enemyPrefab, spawnCenter.position + offset, Quaternion.identity);

            EnemyPatrolAndChase enemy = enemyObj.GetComponent<EnemyPatrolAndChase>();
            enemy.patrolPath = patrolPath;
        }
    }
}
