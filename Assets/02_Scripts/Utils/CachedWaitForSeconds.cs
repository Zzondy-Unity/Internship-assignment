using System.Collections.Generic;
using UnityEngine;

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
