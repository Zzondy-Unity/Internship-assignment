using UnityEngine;

public class Managers : SingletonDontDestroy<Managers>
{
    private DataManager _dataManager;
    private SpawnManager _spawnManager;
    private CharacterManager _characterManager;
    private ResourceManager _resourceManager;
    private GameManager _gameManager;
    private CoroutineManager _coroutineManager;
    private ObjectPoolManager _objectPoolManager;
    private UIManager _uiManager;

    public static DataManager Data { get {return Instance._dataManager; } }
    public static SpawnManager Spawner { get { return Instance._spawnManager; } }
    public static CharacterManager Character { get { return Instance._characterManager; } }
    public static ResourceManager Resource { get { return Instance._resourceManager; } }
    public static GameManager Game { get { return Instance._gameManager; } }
    public static CoroutineManager Coroutine { get { return Instance._coroutineManager; } }
    public static ObjectPoolManager ObjectPool { get { return Instance._objectPoolManager; } }
    public static UIManager UI { get { return Instance._uiManager; } }

    protected override void Awake()
    {
        base.Awake();
        
        InitializeManagers();
    }
    
    private void InitializeManagers()
    {
        _gameManager = new GameManager();
        _dataManager = new DataManager();
        _resourceManager = new ResourceManager();
        _objectPoolManager = CreateManager<ObjectPoolManager>(Instance.transform);
        _coroutineManager = CreateManager<CoroutineManager>(Instance.transform);
        _spawnManager = CreateManager<SpawnManager>(Instance.transform);
        _characterManager = CreateManager<CharacterManager>(Instance.transform);
        _uiManager = CreateManager<UIManager>(Instance.transform);

        _objectPoolManager.Init();
        _coroutineManager.Init();
        _resourceManager.Init();
        _dataManager.Init();
        _spawnManager.Init();
        _characterManager.Init();
        _gameManager.Init();
        _uiManager.Init();
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
