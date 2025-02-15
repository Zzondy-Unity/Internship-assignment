using UnityEngine;

public abstract class Monster : MonoBehaviour, IDamageable
{
    public GameObject prefab;
    
    public MonsterDataSO data { get; protected set; }
    public bool isAlive = true;

    public MonsterController monsterController;
    
    public virtual void Initialize(MonsterDataSO monsterDataSO)
    {
        data = monsterDataSO;
        
        monsterController = GetComponent<MonsterController>();
    }
    
    public bool TakeDamage(int damage)
    {
        return monsterController.TakeDamage(damage);
    }

    
    public Monster Revive(Transform spawnPoint)
    {
        if (isAlive) return null;
        
        isAlive = true;
        monsterController.Heal(data.health);
        this.transform.position = spawnPoint.position;
        WalkToWalkPoint();
        return this;
    }

    private void WalkToWalkPoint()
    {
        monsterController.stateMachine.ChangeState<MonsterWalkState>();
    }

    public int GetMonsterIDOfThis()
    {
        return data.id;
    }

    public void SetWalkPoint(Transform walkPoint)
    {
        monsterController.SetWalkPoint(walkPoint);
    }
}
