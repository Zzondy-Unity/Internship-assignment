using UnityEngine;

public class CharacterManager : MonoBehaviour, IManager
{
    public Player player;

    private const string PlayerPath = "here";
    
    public void Init()
    {
        Player playerPrefab = Resources.Load<Player>(PlayerPath);
        player = Instantiate(playerPrefab);
    }
}
