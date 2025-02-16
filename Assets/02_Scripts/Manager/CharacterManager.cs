using UnityEngine;

/// <summary>
/// 플레이어의 소환을 관리하는 매니저입니다.
/// </summary>
public class CharacterManager : MonoBehaviour, IManager
{
    [HideInInspector]public Player player;
    [SerializeField] Transform playerSpawnPoint;

    private const string PlayerPath = "Prefabs/Entity/Player/";
    private const string archer = "Archer";
    
    public void Init()
    {
        Player playerPrefab = Managers.Resource.LoadAsset<Player>(PlayerPath + archer);
        player = Instantiate(playerPrefab);
        player.transform.position = playerSpawnPoint.position;
        
        player.Init();
    }
}
