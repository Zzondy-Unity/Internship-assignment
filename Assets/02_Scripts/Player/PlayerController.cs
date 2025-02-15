using System;
using UnityEngine;

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
