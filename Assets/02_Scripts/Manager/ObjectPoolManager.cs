using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

/// <summary>
/// 오브젝트 풀링을 위한 매니저입니다.
/// </summary>
public class ObjectPoolManager : MonoBehaviour, IManager
{
    private Dictionary<Type, ObjectPool<GameObject>> poolDictionary = new Dictionary<Type, ObjectPool<GameObject>>();

    public void Init()
    {
        
    }
    
    /// <summary>
    /// 풀을 생성합니다.
    /// </summary>
    /// <param name="type">생성할 타입</param>
    /// <param name="prefab">프리팹</param>
    /// <param name="initialSize">풀 초기 사이즈</param>
    /// <param name="maxSize">최대 사이즈</param>
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
