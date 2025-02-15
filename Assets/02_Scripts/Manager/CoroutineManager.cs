using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineManager : MonoBehaviour, IManager
{
    private Dictionary<int, Coroutine> coroutineDic = new();
    private int index = 0;
    
    public void Init()
    {
        
    }
    
    public int StartManagedCoroutine(IEnumerator routine, Action onComplete = null)
    {
        int key = index++;
        Coroutine coroutine = StartCoroutine(RunCoroutine(key, routine, onComplete));
        coroutineDic.Add(key, coroutine);
        return key;
    }

    private IEnumerator RunCoroutine(int key, IEnumerator routine, Action onComplete = null)
    {
        yield return StartCoroutine(routine);
        onComplete?.Invoke();
        coroutineDic.Remove(key);
    }
    
    public void StopManagedCoroutine(int key)
    {
        if (coroutineDic.TryGetValue(key, out Coroutine coroutine))
        {
            StopCoroutine(coroutine);
            coroutineDic.Remove(key);
        }
    }

    public void StopAllManagedCoroutines()
    {
        foreach (var kvp in coroutineDic)
        {
            StopCoroutine(kvp.Value);
        }
        coroutineDic.Clear();
    }
    
}
