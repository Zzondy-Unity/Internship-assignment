using System;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour, IManager
{
    public void Init()
    {
        
    }
    
    private Dictionary<Type, GameObject> openUI = new Dictionary<Type, GameObject>();
    private Dictionary<Type, GameObject> closeUI = new Dictionary<Type, GameObject>();

    public T Show<T>(object arg = null) where T : UIBase
    {
        Type type = typeof(T);
        var ui = Get<T>(out bool isOpen);

        if (ui == null) return null;
        if (isOpen) return ui;
        
        openUI[type] = ui.gameObject;
        ui.OnShow(arg);
        return ui;
    }

    public void Hide<T>(object arg = null) where T : UIBase
    {
        Type type = typeof(T);
        bool isOpen = false;
        var ui = Get<T>(out isOpen);

        if (isOpen)
        {
            openUI.Remove(type);
            closeUI[type] = ui.gameObject;
            ui.OnHide(arg);
            ui.gameObject.SetActive(false);
        }
    }

    private T Get<T>(out bool isOpen) where T : UIBase
    {
        Type type = typeof(T);

        UIBase ui = null;
        isOpen = false;

        if (openUI.ContainsKey(type))
        {
            ui = openUI[type].GetComponent<UIBase>();
            isOpen = true;
        }
        else if (closeUI.ContainsKey(type))
        {
            ui = closeUI[type].GetComponent<UIBase>();
            closeUI.Remove(type);
        }
        else
        {
            var prefabName = type.Name;
            var prefab = Resources.Load("UI/" + prefabName) as GameObject;
            if (prefab == null)
            {
                return null;
            }
            
            GameObject go = Instantiate(prefab);
            ui = go.GetComponent<UIBase>();
            if (ui == null)
            {
                Destroy(go);
                return null;
            }
        }

        return (T)ui;
    }
}
