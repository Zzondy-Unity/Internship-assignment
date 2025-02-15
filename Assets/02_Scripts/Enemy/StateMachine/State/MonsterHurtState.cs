using System.Numerics;
using UnityEngine;

public class MonsterHurtState : MonsterBaseState
{
    public MonsterHurtState(MonsterController controller) : base(controller)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(controller.monsterAnimationData.HurtParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(controller.monsterAnimationData.HurtParameterHash);
    }

    public override void Update()
    {
        base.Update();
        if (CheckAnimationEnd())
        {
            if (CheckWalkDistance())
            {
                controller.stateMachine.ChangeState<MonsterWalkState>();
            }
            else
            {
                controller.stateMachine.ChangeState<MonsterIdleState>();
            }
        }
    }

    private bool CheckWalkDistance()
    {
        float distance = (controller.walkPoint.position - controller.transform.position).sqrMagnitude;
        if (distance < controller.breakDistance)
        {
            return false;
        }

        return true;
    }

    private bool CheckAnimationEnd()
    {
        AnimatorStateInfo state = controller.animator.GetCurrentAnimatorStateInfo(0);
        
        float normalizedTime = state.normalizedTime;
        if (normalizedTime >= 1f || state.IsTag("hit"))
        {
            return true;
        }
        return false;
    }
}
