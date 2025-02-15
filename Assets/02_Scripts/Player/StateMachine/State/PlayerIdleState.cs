using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{

    
    public PlayerIdleState(PlayerController controller) : base(controller)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(controller.playerAnimationData.IdleParameterHash);
         
 
    }

    public override void Update()
    {
        base.Update();
        if (CheckMonster(out Monster monster))
        {
            PlayerAutoAttackState attackState = controller.playerStateMachine.ChangeState<PlayerAutoAttackState>() as PlayerAutoAttackState;
            attackState.SetTarget(monster);
        }
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(controller.playerAnimationData.IdleParameterHash);
    }
    

}
