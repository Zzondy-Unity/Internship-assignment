using System;
using UnityEngine;

[Serializable]
 public class MonsterAnimationData : AnimationData
{
    [SerializeField] private string hurtParameterName = "hurt";
    [SerializeField] private string deathParameterName = "death";
    
    public int HurtParameterHash { get; private set; }
    public int DeathParameterHash { get; private set; }

    public override void Initialize()
    {
        base.Initialize();
        HurtParameterHash = Animator.StringToHash(hurtParameterName);
        DeathParameterHash = Animator.StringToHash(deathParameterName);
    }
}
