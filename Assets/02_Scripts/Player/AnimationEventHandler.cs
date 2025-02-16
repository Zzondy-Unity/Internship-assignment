using UnityEngine;

/// <summary>
/// 자식 컴포넌트에 존재하는 애니메이션의 이벤트를 대신 실행해주는 클래스입니다.
/// </summary>
public class AnimationEventHandler : MonoBehaviour
{
    public void OnAttackAnimationEvent()
    {
        EventManager.Publish(GameEventType.OnShoot);
    }
}
