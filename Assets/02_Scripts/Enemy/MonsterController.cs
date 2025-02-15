using System;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public Monster monster { get; private set; }
    [field : SerializeField] public MonsterAnimationData monsterAnimationData { get; private set; }
    public Animator animator { get; private set; }
    private int health = 0;
    public Transform walkPoint { get; private set; }
    public float breakDistance { get; } = 1f;

    public MonsterStateMachine stateMachine { get; private set; }
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
        health = monster.data.health;
        
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
            Debug.Log($"Change to HurtState. health is {health}");
            stateMachine.ChangeState<MonsterHurtState>();
        }
        return true;
    }
    
    private void OnDead()
    {
        stateMachine.ChangeState<MonsterDeathState>();
        EventManager.Publish(GameEventType.OnMonsterDead, monster);
    }

    public void SetWalkPoint(Transform walkPoint)
    {
        this.walkPoint = walkPoint;
    }

    public void Heal(int amount)
    {
        health = Mathf.Min(health + amount, monster.data.health);
    }

    private bool IsGround()
    {
        float rayDistance = 0.2f;
        Vector2 origin = GroundPoint.position;

        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, rayDistance, GroundMask);
        Debug.DrawRay(origin, Vector2.down * rayDistance, Color.red);
        
        return hit.collider != null;
    }
}
