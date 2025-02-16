using UnityEngine;

/// <summary>
/// 체력관련 로직을 담당하는 클래스입니다.
/// </summary>
[RequireComponent(typeof(HPBar))]
public class MonsterHealthSystem : MonoBehaviour
{
    private Monster monster;
    private HPBar healthBar;
    private float health = 0;
    private float maxHealth;

    public void Init(Monster monster)
    {
        this.monster = monster;
        maxHealth = monster.data.health;
        health = maxHealth;
        
        healthBar = GetComponent<HPBar>();
        healthBar.ShowHPBar();
        healthBar.Init();
    }
    
    /// <summary>
    /// 데미지를 계산합니다.
    /// </summary>
    /// <param name="damage">데미지의 총량(양수)</param>
    /// <returns>데미지를 입을 경우 true를 반환합니다.</returns>
    public bool TakeDamage(int damage)
    {
        if(!monster.isAlive) return false;
        if (damage <= 0) return false;
        
        health = Mathf.Max(0, health - damage);
        if (health == 0)
        {
            monster.isAlive = false;
            OnDead();
        }
        else
        {
            monster.monsterController.stateMachine.ChangeState<MonsterHurtState>();
        }
        healthBar.UpdateHPBar(health / maxHealth);
        return true;
    }
    
    public void Heal(int amount)
    {
        health = Mathf.Min(health + amount, maxHealth);
        healthBar.UpdateHPBar(health / maxHealth);
    }

    /// <summary>
    /// 죽었을 때의 행동을 정의합니다.
    /// </summary>
    private void OnDead()
    {
        monster.monsterController.stateMachine.ChangeState<MonsterDeathState>();
        EventManager.Publish(GameEventType.OnMonsterDead, monster);

        if (Managers.UI.IsOpened<MonsterIndicator>() != null)
        {
            Managers.UI.Hide<MonsterIndicator>();
        }
    }

    public void HideHPBar()
    {
        healthBar.HideHPBar();
    }

    public void ShowHPBar()
    {
        healthBar.ShowHPBar();
    }
}
