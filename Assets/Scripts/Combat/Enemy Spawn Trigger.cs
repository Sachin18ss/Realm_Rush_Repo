using UnityEngine;

public class EnemySpawnTrigger : MonoBehaviour
{
    public EnemySpawner spawner;
    public int enemyCount;

    private bool triggered;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return;
        if (!other.CompareTag("Player")) return;

        triggered = true;
        spawner.SpawnEnemies(enemyCount);

        // Optional: disable trigger completely
        gameObject.SetActive(false);
    }
}
