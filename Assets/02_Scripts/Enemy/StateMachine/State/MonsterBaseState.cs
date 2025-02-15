public class MonsterBaseState : IState
{
    protected MonsterController controller;
    
    public MonsterBaseState(MonsterController controller)
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
