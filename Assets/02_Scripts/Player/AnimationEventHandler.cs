using UnityEngine;

public class AnimationEventHandler : MonoBehaviour
{
    public void OnAttackAnimationEvent()
    {
        EventManager.Publish(GameEventType.OnShoot);
    }
}
