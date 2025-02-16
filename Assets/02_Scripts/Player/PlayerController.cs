using UnityEngine;

/// <summary>
/// 플레이어의 행동을 조절하는 클래스입니다.
/// 상태머신과 AttackController를 가집니다.
/// </summary>
public class PlayerController : MonoBehaviour
{
    [field: Header("AnimationData")]
    [field: SerializeField] public PlayerAnimationData playerAnimationData { get; private set; }
    
    [SerializeField] private LayerMask monsterLayer;
    
    public Animator animator { get; private set; }
    public PlayerStateMachine playerStateMachine { get; private set; }
    public PlayerAttackController attackController { get; private set; }

    public void Init(Player player)
    {
        animator = GetComponentInChildren<Animator>();
        playerAnimationData.Initialize();
        attackController = GetComponent<PlayerAttackController>();
        attackController.Init(player);
        
        playerStateMachine = new PlayerStateMachine(player);
        playerStateMachine.ChangeState<PlayerIdleState>();
    }

    private void Update()
    {
        playerStateMachine.Update();
    }

    public int GetMonsterLayerMask()
    {
        return monsterLayer;
    }
}
