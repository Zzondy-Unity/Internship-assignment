using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonsterIndicator : UIPopup
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private Image monsterImage;
    [SerializeField] private TextMeshProUGUI descText;
    
    
    public override void OnShow(object args)
    {
        base.OnShow(args);
        if (args is Monster monster)
        {
            SetIndicator(monster);
        }
        else
        {
            Hide();
        }
    }

    public override void Hide()
    {
        base.Hide();
        Managers.UI.Hide<MonsterIndicator>();
    }

    public override void OnHide(object args)
    {
        base.OnHide(args);
        ClearIndicator();
    }

    private void SetIndicator(Monster monster)
    {
        nameText.text = monster.data.monsterName;
        monsterImage.sprite = monster.spriteRenderer.sprite;
        
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"등급 : {monster.data.grade}\n");
        sb.AppendLine($"속도 : {monster.data.speed}\n");
        sb.AppendLine($"체력 : {monster.data.health}");
        descText.text = sb.ToString();
    }

    private void ClearIndicator()
    {
        nameText.text = string.Empty;
        monsterImage.sprite = null;
        descText.text = string.Empty;
    }
}
