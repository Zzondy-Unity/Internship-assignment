using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 코루틴에 사용되는 WaitForSeconds를 캐싱해둡니다.
/// </summary>
public static class CachedWaitForSeconds
{
    private static readonly Dictionary<float, WaitForSeconds> waitForSecondsDic = new();

    public static WaitForSeconds Get(float seconds)
    {
        if (!waitForSecondsDic.TryGetValue(seconds, out var waitForSeconds))
        {
            waitForSeconds = new WaitForSeconds(seconds);
            waitForSecondsDic.Add(seconds, waitForSeconds);
        }
        return waitForSeconds;
    }
}
