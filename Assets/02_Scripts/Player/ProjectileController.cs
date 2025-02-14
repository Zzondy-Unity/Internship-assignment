using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private Arrow _arrow;

    public void Init()
    {
        _arrow = Managers.Resource.LoadAsset<Arrow>(Constants.arrowPrefabPath + "/normalArrow");
    }

    public void Fire(Vector3 direction, int damage)
    {
        var arrow = Instantiate(_arrow);
        arrow.Init(direction, damage);
    }
}
