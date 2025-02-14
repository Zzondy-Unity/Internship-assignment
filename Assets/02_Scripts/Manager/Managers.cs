using UnityEngine;

public class Managers : SingletonDontDestroy<Managers>
{
    public DataManager _dataManager;
    public SpawnManager _spawnManager;

    protected override void Awake()
    {
        base.Awake();
        
        CreateManagers();
        InitializeManagers();
    }

    private void CreateManagers()
    {
        _dataManager = new DataManager();
        _spawnManager = new SpawnManager();
    }
    
    private void InitializeManagers()
    {
        _dataManager.Init();
        _spawnManager.Init();
    }
}
