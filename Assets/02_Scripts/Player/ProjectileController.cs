using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    // 화살 풀링 생각
    private Arrow _arrow;
    private Camera _camera;
    [SerializeField] private Transform arrowPivot;

    public void Init()
    {
        _arrow = Managers.Resource.LoadAsset<Arrow>(Constants.arrowPrefabPath + "/normalArrow");
        _camera = Camera.main;
        
        Managers.ObjectPool.CreatePool(typeof(Arrow), _arrow.gameObject);
    }

    public void Fire(Vector3 direction, int damage)
    {
        var arrow = Managers.ObjectPool.SpawnFromPool(typeof(Arrow), arrowPivot.position, Quaternion.identity).GetComponent<Arrow>();
        arrow.transform.position = arrowPivot.position;
        arrow.Init(direction, damage, _camera);
    }
}
