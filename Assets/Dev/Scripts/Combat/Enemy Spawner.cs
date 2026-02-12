using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnCenter;
    public float spawnRadius = 5f;
    public void SpawnEnemies(int count)
    {
        
        for (int i = 0; i < count; i++)
        {
            Vector3 offset = Random.insideUnitSphere * spawnRadius;
            offset.y = 0f; // keep on ground
            Vector3 spawnPos = spawnCenter.position + offset;

            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }
    }
}
