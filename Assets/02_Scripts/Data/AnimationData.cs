using System;
using UnityEngine;

[Serializable]
public class AnimationData
{
    [SerializeField] private string idleParameterName = "idle";
    [SerializeField] private string walkParameterName = "walk";
    
    public int IdleParameterHash { get; private set; }
    public int WalkParameterHash { get; private set; }

    public virtual void Initialize()
    {
        IdleParameterHash = Animator.StringToHash(idleParameterName);
        WalkParameterHash = Animator.StringToHash(walkParameterName);
    }
}
