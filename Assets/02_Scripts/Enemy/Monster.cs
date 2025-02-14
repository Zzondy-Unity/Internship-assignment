using UnityEngine;

public abstract class Monster : MonoBehaviour, IDamageable
{
    public GameObject prefab;
    
    protected MonsterDataSO data;
    protected int health;
    
    public void Initialize(MonsterDataSO monsterDataSO)
    {
        data = monsterDataSO;
        health = data.health;
    }
    
    public bool TakeDamage(int damage)
    {
        return true;
    }

    public void OnDead()
    {
        //TODO :: 죽었을 때 일어나는 일
    }
}
