using UnityEngine;

public class UIBase : MonoBehaviour
{
    public virtual void OnShow(object args)
    {
        RectTransform rect = GetComponent<RectTransform>();
        rect.localPosition = Vector3.zero;
        rect.localScale = Vector3.one;
        rect.offsetMin = Vector2.zero;
        rect.offsetMax = Vector2.zero;
    }

    public virtual void OnHide(object args)
    {
        
    }
}
