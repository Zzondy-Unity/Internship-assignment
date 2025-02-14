using UnityEngine;

public class Managers : SingletonDontDestroy<Managers>
{
    private DataManager _dataManager;
    private SpawnManager _spawnManager;
    private CharacterManager _characterManager;
    private ResourceManager _resourceManager;
    private GameManager _gameManager;

    public static DataManager Data { get {return Instance._dataManager; } }
    public static SpawnManager Spawner { get { return Instance._spawnManager; } }
    public static CharacterManager Character { get { return Instance._characterManager; } }
    public static ResourceManager Resource { get { return Instance._resourceManager; } }
    public static GameManager Game { get { return Instance._gameManager; } }

    protected override void Awake()
    {
        base.Awake();
        
        InitializeManagers();
    }
    
    private void InitializeManagers()
    {
        _gameManager = new GameManager();
        _dataManager = new DataManager();
        _spawnManager = new SpawnManager();
        _resourceManager = new ResourceManager();
        _characterManager = CreateManager<CharacterManager>(Instance.transform);
        
        _resourceManager.Init();
        _dataManager.Init();
        _spawnManager.Init();
        _characterManager.Init();
        _gameManager.Init();
    }

    private T CreateManager<T>(Transform parent) where T : Component, IManager
    {
        T manager = GetComponentInChildren<T>(parent);
        if (manager == null)
        {
            GameObject obj = new GameObject(typeof(T).Name);
            manager = obj.AddComponent<T>();
            obj.transform.SetParent(parent);
        }
        
        return manager;
    }
}
