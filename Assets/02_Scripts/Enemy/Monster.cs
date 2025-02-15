using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Monster : MonoBehaviour, IDamageable, IPointerClickHandler
{
    public MonsterDataSO data { get; protected set; }
    public bool isAlive = true;

    public MonsterController monsterController;
    private Transform walkPoint;
    public SpriteRenderer spriteRenderer { get; protected set; }
    public MonsterHealthSystem monsterHealthSystem { get; protected set; }
    
    public virtual void Initialize(MonsterDataSO monsterDataSO)
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        data = monsterDataSO;
        
        monsterController = GetComponent<MonsterController>();
        monsterHealthSystem = GetComponent<MonsterHealthSystem>();
        
        monsterController.SetWalkPoint(walkPoint);
        monsterController.Initialize(this);
        
        monsterHealthSystem.Init(this);
    }
    
    public bool TakeDamage(int damage)
    {
        return monsterHealthSystem.TakeDamage(damage);
    }

    
    public Monster Revive(Transform spawnPoint)
    {
        if (isAlive) return null;

        isAlive = true;
        monsterHealthSystem.Heal(data.health);
        monsterHealthSystem.ShowHPBar();
        this.transform.position = spawnPoint.position;
        
        gameObject.SetActive(true);
        spriteRenderer.color = Color.white;
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
        this.walkPoint = walkPoint;
    }
    
    
    public void OnPointerClick(PointerEventData eventData)
    {
        Managers.UI.Show<MonsterIndicator>(this);
    }
}
