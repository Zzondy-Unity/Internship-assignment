using UnityEngine;

public abstract class PlayerBaseState : IState
{
    protected PlayerController controller;
    
    public PlayerBaseState(PlayerController controller)
    {
        this.controller = controller;
    }
    
    public virtual void Enter()
    {
        
    }

    public virtual void Update()
    {
        
    }

    public virtual void Exit()
    {
        
    }

    protected void StartAnimation(int animationHash)
    {
        controller.animator.SetBool(animationHash, true);
    }

    protected void StopAnimation(int animationHash)
    {
        controller.animator.SetBool(animationHash, false);
    }
}
