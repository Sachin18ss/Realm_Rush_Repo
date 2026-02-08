using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] boundaryPoints;

    public void SpawnEnemies(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Transform point = boundaryPoints[Random.Range(0, boundaryPoints.Length)];
            Instantiate(enemyPrefab, point.position, point.rotation);
        }
    }
}
