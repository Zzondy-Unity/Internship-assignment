using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [field: Header("AnimationData")]
    [field: SerializeField] public PlayerAnimationData playerAnimationData { get; private set; }
    
    public Animator animator { get; private set; }
    public PlayerStateMachine playerStateMachine { get; private set; }

    public void Init(Player player)
    {
        animator = GetComponentInChildren<Animator>();
        playerAnimationData.Initialize();
        
        playerStateMachine = new PlayerStateMachine(player);
    }

    private void Update()
    {
        playerStateMachine.Update();
    }
}
