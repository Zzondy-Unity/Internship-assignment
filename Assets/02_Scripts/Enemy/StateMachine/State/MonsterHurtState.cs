using UnityEngine;

public class MonsterHurtState : MonsterBaseState
{
    public MonsterHurtState(MonsterController controller) : base(controller)
    {
    }

    public override void Enter()
    {
        base.Enter();
        controller.animator.SetTrigger(controller.monsterAnimationData.HurtParameterHash);
        //StartAnimation(controller.monsterAnimationData.HurtParameterHash);
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
    
        if (state.normalizedTime >= 1f && (state.IsTag("hit") || state.IsName("hurt")))
        {
            return true;
        }

        if (!(state.IsTag("hit") || state.IsName("hurt")))
        {
            // hit태그나 hurt이름이 아닌 애니메이션중일경우 애니메이션이 끝난걸로 간주
            return true;
        }
    
        return false;
    }
}
