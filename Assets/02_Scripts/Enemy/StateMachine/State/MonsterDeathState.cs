using System.Collections;
using UnityEngine;

public class MonsterDeathState : MonsterBaseState
{
    private int deathCoroutineKey = 0;
    private float deathAnimationTime = 1f;
    
    public MonsterDeathState(MonsterController controller) : base(controller)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(controller.monsterAnimationData.DeathParameterHash);
        deathAnimationTime = controller.animator.GetCurrentAnimatorClipInfo(0).GetLength(0);
        deathCoroutineKey = Managers.Coroutine.StartManagedCoroutine(StartBlink(), Disappear);
    }
    
    public override void Exit()
    {
        base.Exit();
        StopAnimation(controller.monsterAnimationData.DeathParameterHash);
        Managers.Coroutine.StopManagedCoroutine(deathCoroutineKey);
    }

    private void Disappear()
    {
        controller.gameObject.SetActive(false);
    }

    private IEnumerator StartBlink()
    {
        SpriteRenderer SR = controller.monster.spriteRenderer;
        yield return CachedWaitForSeconds.Get(deathAnimationTime);
        
        for (float t = 0; t < 1; t += Time.deltaTime * 0.5f)
        {
            SR.color = new Color(1, 1, 1, 1 - t);
            yield return null;
        }
    }
    
}
