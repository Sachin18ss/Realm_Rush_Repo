using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 4;

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    public float shootInterval = 2f;

    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating(nameof(ShootAtPlayer), 1f, shootInterval);
    }

    void ShootAtPlayer()
    {
        if (player == null) return;

        Vector3 direction = (player.position - firePoint.position).normalized;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = direction * bulletSpeed;
        Destroy(bullet, 5f);

    }
    public void TakeDamage()
    {
        health--;

        if (health <= 0)
        {
            QuestManager.Instance.ReportProgress<KillQuestSO>();
            Destroy(gameObject);
        }
    }
}



