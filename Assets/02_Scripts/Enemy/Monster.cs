using UnityEngine;

public abstract class Monster : MonoBehaviour, IDamageable
{
    public GameObject prefab;
    
    protected MonsterDataSO data;
    protected int health;
    public bool isAlive = true;
    
    public virtual void Initialize(MonsterDataSO monsterDataSO)
    {
        data = monsterDataSO;
        health = data.health;
    }
    
    public bool TakeDamage(int damage)
    {
        if(!isAlive) return false;
        if (damage <= 0) return false;
        
        health = Mathf.Max(0, health - damage);
        if (health == 0)
        {
            isAlive = false;
            OnDead();
        }
        return true;
    }

    private void OnDead()
    {
        // TODO :: 죽었을 때 일어나는 일
        // 애니메이션 실행
        Managers.Spawner.SpawnMonsters();
    }
}
