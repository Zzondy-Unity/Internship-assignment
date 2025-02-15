using UnityEngine;

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

    private void OnDead()
    {
        monster.monsterController.stateMachine.ChangeState<MonsterDeathState>();
        EventManager.Publish(GameEventType.OnMonsterDead, monster);
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
