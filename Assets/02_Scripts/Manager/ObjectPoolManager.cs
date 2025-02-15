using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolManager : MonoBehaviour, IManager
{
    private Dictionary<Type, ObjectPool<GameObject>> poolDictionary = new Dictionary<Type, ObjectPool<GameObject>>();

    public void Init()
    {
        
    }

    public void CreatePool(Type type, GameObject prefab, int initialSize = 10, int maxSize = 20)
    {
        if (poolDictionary.ContainsKey(type))
        {
            return;
        }
        
        ObjectPool<GameObject> pool = new ObjectPool<GameObject>(
            createFunc: () =>
            {
                GameObject obj = Instantiate(prefab);
                obj.SetActive(false);
                return obj;
            },
            actionOnGet: obj =>
            {
                obj.SetActive(true);
            },
            actionOnRelease: obj =>
            {
                obj.SetActive(false);
            },
            actionOnDestroy: obj =>
            {
                Destroy(obj);
            },
            collectionCheck: true,
            defaultCapacity: initialSize,
            maxSize: maxSize
            );
        
        poolDictionary.Add(type, pool);
    }

    public GameObject SpawnFromPool(Type type, Vector3 position, Quaternion rotation)
    {
        if (poolDictionary.TryGetValue(type, out ObjectPool<GameObject> pool))
        {
            GameObject obj = pool.Get();
            obj.transform.position = position;
            obj.transform.rotation = rotation;
            return obj;
        }

        return null;
    }

    public void ReturnToPool(Type type, GameObject obj)
    {
        if (poolDictionary.TryGetValue(type, out ObjectPool<GameObject> pool))
        {
            pool.Release(obj);
        }
        else
        {
            Destroy(obj);
        }
    }
}
