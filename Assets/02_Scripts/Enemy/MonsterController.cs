using UnityEngine;

/// <summary>
/// 몬스터의 행동을 조절합니다.
/// 상태머신을 포함합니다.
/// </summary>
public class MonsterController : MonoBehaviour
{
    public Monster monster { get; private set; }
    public Animator animator { get; private set; }
    public Transform walkPoint { get; private set; }
    public float breakDistance { get; } = 1f;

    public MonsterStateMachine stateMachine { get; private set; }
    [field : SerializeField] public MonsterAnimationData monsterAnimationData { get; private set; }
    public Rigidbody2D rb2D { get; private set; }

    [SerializeField] private LayerMask GroundMask;
    [SerializeField] private Transform GroundPoint;
    
    public bool isGrounded { get; private set; }
    
    
    public void Initialize(Monster monster)
    {
        monsterAnimationData = new MonsterAnimationData();
        monsterAnimationData.Initialize();
        
        animator = GetComponentInChildren<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        stateMachine = new MonsterStateMachine(monster);
        
        this.monster = monster;
        
        stateMachine.ChangeState<MonsterWalkState>();
    }

    private void Update()
    {
        if(stateMachine != null && monster.isAlive)
            stateMachine.Update();
    }

    private void FixedUpdate()
    {
        isGrounded = IsGround();
    }


    public void SetWalkPoint(Transform walkPoint)
    {
        this.walkPoint = walkPoint;
    }

    /// <summary>
    /// 지면에 붙어있는지 여부를 판별합니다.
    /// </summary>
    /// <returns></returns>
    private bool IsGround()
    {
        float rayDistance = 0.2f;
        Vector2 origin = GroundPoint.position;
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, rayDistance, GroundMask);
        
        return hit.collider != null;
    }
}
