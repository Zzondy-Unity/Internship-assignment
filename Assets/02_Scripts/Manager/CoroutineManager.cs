using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MonoBehaviour가 아닌 클래스 대신 코루틴을 돌려주는 매니저입니다.
/// </summary>
public class CoroutineManager : MonoBehaviour, IManager
{
    private Dictionary<int, Coroutine> coroutineDic = new();
    private int index = 0;
    
    public void Init()
    {
        
    }
    
    /// <summary>
    /// 코루틴을 전달받아 작동합니다.
    /// </summary>
    /// <param name="routine">작동할 코루틴</param>
    /// <param name="onComplete">작동 완료 콜백</param>
    /// <returns>key를 반환하여 해당 key를 통해 코루틴을 조절할 수 있습니다.</returns>
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
