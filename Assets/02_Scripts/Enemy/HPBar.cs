using System;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] private CanvasGroup HPCanvasGroup;
    [SerializeField] private Image HP;
    [SerializeField] private Image delayHP;
    private float decreaseSpeed = 10f;
    private bool isDamaging = false;

    public void Init()
    {
        RestoreHPBar();
    }

    public void HideHPBar()
    {
        HPCanvasGroup.alpha = 0;
    }

    public void ShowHPBar()
    {
        HPCanvasGroup.alpha = 1;
    }

    public void UpdateHPBar(float value)
    {
        isDamaging = true;
        HP.fillAmount = value;
    }

    private void BackHPDecrease()
    {
        delayHP.fillAmount = Mathf.Lerp(delayHP.fillAmount, HP.fillAmount, Time.deltaTime * decreaseSpeed);
        if (Mathf.Approximately(HP.fillAmount, delayHP.fillAmount))
        {
            isDamaging = false;
        }
    }

    private void RestoreHPBar()
    {
        HP.fillAmount = 1f;
        delayHP.fillAmount = 1f;
        isDamaging = false;
    }

    private void Update()
    {
        if (isDamaging)
        {
            BackHPDecrease();
        }
    }
}
