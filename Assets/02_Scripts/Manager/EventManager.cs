using System;
using System.Collections.Generic;
using UnityEngine;

public delegate void EventListener(object args);

public static class EventManager
{
    private static readonly Dictionary<GameEventType, List<EventListener>> eventListenerDictionary = new Dictionary<GameEventType, List<EventListener>>();
    
    public static void Subscribe(GameEventType type, EventListener listener)
    {
        if (!eventListenerDictionary.TryGetValue(type, out var list))
        {
            list = new List<EventListener>();
            eventListenerDictionary.Add(type, list);
        }
        list.Add(listener);
    }

    public static void UnSubscribe(GameEventType type, EventListener listener)
    {
        if (!eventListenerDictionary.TryGetValue(type, out var list))
        {
            return;
        }
        
        list.Remove(listener);
        if (list.Count == 0)
        {
            eventListenerDictionary.Remove(type);
        }
    }

    public static void Publish(GameEventType type, object arg = null)
    {
        if (!eventListenerDictionary.TryGetValue(type, out var list))
        {
            return;
        }

        var listeners = new List<EventListener>(list);

        foreach (var listener in listeners)
        {
            try
            {
                listener?.Invoke(arg);
            }
            catch (Exception e)
            {
                Debug.Log($"Error publishing event {type}: {e}");
            }
        }
    }
}
