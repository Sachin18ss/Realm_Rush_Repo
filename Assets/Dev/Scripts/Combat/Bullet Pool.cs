using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
public class BulletPool : MonoBehaviour
{
    [SerializeField]private GameObject _bulletPrefab;
    [SerializeField]private int _poolSize = 15;

    private List<GameObject> _bullerPool = new List<GameObject>();

    public void Start()
    {
        for(int i = 0; i < _poolSize;i++)
        {
            GameObject obj = Instantiate(_bulletPrefab);
            obj.SetActive(false);

            _bullerPool.Add(obj);
        }
    }

    public GameObject GetBullet()
    {
        foreach(GameObject bullet in _bullerPool)
        {
            if(!bullet.activeInHierarchy)
            {
                return bullet;
            }
        }
        return null;
    }
}
