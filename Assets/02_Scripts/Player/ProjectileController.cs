using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    // 화살 풀링 생각
    private Arrow _arrow;
    private Transform spawnPivot;

    public void Init()
    {
        _arrow = Managers.Resource.LoadAsset<Arrow>(Constants.arrowPrefabPath + "/normalArrow");
    }

    public void Fire(Vector3 direction, int damage)
    {
        var arrow = Instantiate(_arrow);
        arrow.transform.position = spawnPivot.position;
        arrow.Init(direction, damage);
    }
}
