using System;
using UnityEngine;
using UnityEngine.UI;

public class UIPopup : UIBase
{
    [SerializeField] private Button exitBtn;

    protected virtual void Awake()
    {
        if(exitBtn != null)
            exitBtn.onClick.AddListener(Hide);
    }

    public virtual void Hide()
    {
        
    }
}
