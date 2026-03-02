using UnityEngine;
using System.Collections;
public class Bullet : MonoBehaviour
{
    private float _moveSpeed = 10f;
    private float _lifeTime = 3f;

    private void OnEnable()
    {
        Invoke(nameof(DeactiveBullet), _lifeTime);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);
    }
    void OnCollisionEnter(Collision collision)
    {
        DeactiveBullet();
    }

    private void DeactiveBullet()
    {
        CancelInvoke();
        gameObject.SetActive(false);
    }
}
