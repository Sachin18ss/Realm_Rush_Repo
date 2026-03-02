using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Camera cam;
    public float range = 100f;
    public Transform bulletSpawnPoint;
    public BulletPool bulletPool;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, range))
            {
                Enemy enemy = hit.collider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage();
                }
            }

            GameObject bullet = bulletPool.GetBullet();
            if(bullet!=null)
            {
                bullet.transform.position = bulletSpawnPoint.position + transform.forward;
                bullet.transform.rotation = bulletSpawnPoint.rotation;
                bullet.SetActive(true);
            }
        }
    }
}
