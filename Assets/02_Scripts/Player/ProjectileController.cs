using UnityEngine;

/// <summary>
/// 투사체를 관리하는 클래스입니다.
/// </summary>
public class ProjectileController : MonoBehaviour
{
    private Arrow _arrow;
    private Camera _camera;
    [SerializeField] private Transform arrowPivot;

    /// <summary>
    /// 초기화시 화살 클래스의 풀을 만듭니다.
    /// </summary>
    public void Init()
    {
        _arrow = Managers.Resource.LoadAsset<Arrow>(Constants.arrowPrefabPath + "/normalArrow");
        _camera = Camera.main;
        
        Managers.ObjectPool.CreatePool(typeof(Arrow), _arrow.gameObject);
    }

    /// <summary>
    /// 풀링한 화살을 초기화하고 발사합니다.
    /// </summary>
    /// <param name="direction"></param>
    /// <param name="damage"></param>
    public void Fire(Vector3 direction, int damage)
    {
        var arrow = Managers.ObjectPool.SpawnFromPool(typeof(Arrow), arrowPivot.position, Quaternion.identity).GetComponent<Arrow>();
        arrow.transform.position = arrowPivot.position;
        arrow.Init(direction, damage, _camera);
    }
}
