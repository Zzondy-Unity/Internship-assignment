using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Monster : MonoBehaviour, IDamageable, IPointerClickHandler
{
    public MonsterDataSO data { get; protected set; }   // 몬스터의 기본 정보 

    public MonsterController monsterController;         
    private Transform walkPoint;    // 몬스터가 걸어가야할 위치입니다.
    public SpriteRenderer spriteRenderer { get; protected set; }
    public MonsterHealthSystem monsterHealthSystem { get; protected set; }
    public bool isAlive = true;
    
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

    /// <summary>
    /// 몬스터를 부활시킵니다.
    /// </summary>
    /// <param name="spawnPoint"></param>
    /// <returns></returns>
    public Monster Revive(Transform spawnPoint)
    {
        // 살아있는 몬스터일 경우 null을 반환합니다.
        if (isAlive) return null;
        
        // 체력 및 위치를 되돌립니다.
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
    
    /// <summary>
    /// 몬스터 클릭시 정보를 보여주는 popup UI를 띄웁니다.
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        if(isAlive)
            Managers.UI.Show<MonsterIndicator>(this);
    }
}
