using System;
using UnityEngine;

[Serializable]
public class PlayerAnimationData : AnimationData
{
    [SerializeField] private string attackParameterName = "attack";
    
    public int AttackParameterHash { get; private set; }

    public override void Initialize()
    {
        base.Initialize();
        AttackParameterHash = Animator.StringToHash(attackParameterName);
    }
}
