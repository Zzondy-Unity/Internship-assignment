public class PlayerAutoAttackState : PlayerBaseState
{
    public PlayerAutoAttackState(PlayerController controller) : base(controller)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(controller.playerAnimationData.AttackParameterHash);
    }

    public override void Update()
    {
        base.Update();
        if (CheckAttackEnd())
        {
            controller.playerStateMachine.ChangeState<PlayerAutoAttackState>();
        }
    }
    
    public override void Exit()
    {
        base.Exit();
        StopAnimation(controller.playerAnimationData.AttackParameterHash);
    }
    
    //공격이 끝나면 다시 공격
    private bool CheckAttackEnd()
    {
        float normalizedTime = controller.animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
        if (normalizedTime >= 1f)
        {
            return true;
        }

        return false;
    }
}
