using UnityEngine;

public class AnimationEventHandler : MonoBehaviour
{
    public void OnAttackAnimationEvent()
    {
        Managers.Character.player.attackController.ShootArrow();
    }
}
