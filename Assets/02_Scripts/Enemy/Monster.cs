using UnityEngine;

public abstract class Monster : MonoBehaviour, IDamageable
{
    public GameObject prefab;
    
    protected MonsterDataSO data;
    protected int health;
    public bool isAlive = true;
    private Transform walkPoint;
    
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
        EventManager.Publish(GameEventType.OnMonsterDead, this);
        // 애니메이션 실행
    }

    public Monster Revive(Transform spawnPoint)
    {
        if (isAlive) return null;
        
        isAlive = true;
        health = data.health;
        this.transform.position = spawnPoint.position;
        WalkToWalkPoint();
        return this;
    }

    private void WalkToWalkPoint()
    {
        //WalkeState로 변경 후 해당 위치로 이동
    }

    public int GetMonsterIDOfThis()
    {
        return data.id;
    }

    public void SetWalkPoint(Transform walkPoint)
    {
        this.walkPoint = walkPoint;
    }
}
