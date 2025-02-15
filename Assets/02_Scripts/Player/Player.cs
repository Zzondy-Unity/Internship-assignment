using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerData PlayerData;
    public PlayerController playerController;
    
    public void Init()
    {
        PlayerData = new PlayerData();
        playerController = GetComponent<PlayerController>();
        
        playerController.Init(this);
    }
}
