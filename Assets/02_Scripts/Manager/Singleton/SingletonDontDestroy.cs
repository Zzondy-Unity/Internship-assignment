using System;
using UnityEngine;

public class SingletonDontDestroy<T> :  Singleton<T> where T : MonoBehaviour
{
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }
}
