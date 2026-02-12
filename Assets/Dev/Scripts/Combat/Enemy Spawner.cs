using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnCenter;
    public float spawnRadius = 4f;

    private List<EnemyPatrolAndChase> spawnedEnemies = new();
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

            spawnedEnemies.Add(enemy);
        }
    }

    public void DisableChaseInThisRoom()
    {
        foreach (var enemy in spawnedEnemies)
        {
            if (enemy != null)
                enemy.SetChaseAllowed(false);
        }
    }

    public void EnableChaseInThisRoom()
    {
        foreach (var enemy in spawnedEnemies)
        {
            if (enemy != null)
                enemy.SetChaseAllowed(true);
        }
    }
}
