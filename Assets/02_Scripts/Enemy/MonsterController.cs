using System;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public Monster monster { get; private set; }
    public MonsterAnimationData monsterAnimationData { get; private set; }
    public Animator animator { get; private set; }
    private int health = 0;
    private Transform walkPoint;
    
    public MonsterStateMachine stateMachine { get; private set; }

    public void Initialize(Monster monster)
    {
        monsterAnimationData = new MonsterAnimationData();
        
        animator = GetComponentInChildren<Animator>();
        stateMachine = new MonsterStateMachine(monster);
        
        this.monster = monster;
        health = monster.data.health;
    }

    private void Update()
    {
        if(stateMachine != null && monster.isAlive)
            stateMachine.Update();
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
        return true;
    }
    
    private void OnDead()
    {
        animator.SetBool(monsterAnimationData.DeathParameterHash, true);
        EventManager.Publish(GameEventType.OnMonsterDead, this);
    }

    public void SetWalkPoint(Transform walkPoint)
    {
        this.walkPoint = walkPoint;
    }

    public void Heal(int amount)
    {
        health = Mathf.Min(health + amount, monster.data.health);
    }
}
