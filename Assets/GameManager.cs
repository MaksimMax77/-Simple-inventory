using DataProvider;
using EventSubscriber;
using GameWindow;
using UnityEngine;
using InventorySystem;
using InventorySystem.InventorySettings;
using Items;

public class GameManager : MonoBehaviour
{
    [SerializeField] private InventorySettings _inventorySettings;
    [SerializeField] private InventoryView _inventoryView;
    [SerializeField] private GameWindowView _gameWindowView;
    [SerializeField] private ItemsManager _itemsManager;

    private GameWindowController _gameWindowController;
    private InventoryController _inventoryController;
    private InventoryModel _inventoryModel;
    private InventoryDataProvider _inventoryDataProvider;
    private SubscribeManager _subscribeManager;
    public static GameManager Instance { get; private set; }
    public ItemsManager ItemsManager => _itemsManager;
    public InventoryDataProvider InventoryDataProvider => _inventoryDataProvider;


    private void Awake()
    {
        Instance = this;
        _subscribeManager = new SubscribeManager();
        _inventoryDataProvider = new InventoryDataProvider();
        _inventoryModel = new InventoryModel(_inventorySettings);
        _inventoryController = new InventoryController(_inventoryModel, _inventoryView, _inventorySettings);
        _gameWindowController = new GameWindowController(_inventoryModel, _gameWindowView, _itemsManager);
        Subscribe();
        _inventoryDataProvider.LoadData();
    }

    private void Subscribe()
    {
        _inventoryModel.InventoryUpdated += _inventoryDataProvider.OnInventoryUpdated;
        _inventoryDataProvider.DataLoaded += _inventoryModel.OnDataLoad;
        _subscribeManager.Add(_inventoryController);
        _subscribeManager.Add(_gameWindowController);
        _subscribeManager.Subscribe();
    } 
    private void UnSubscribe()
    {
        _inventoryModel.InventoryUpdated -= _inventoryDataProvider.OnInventoryUpdated;
        _inventoryDataProvider.DataLoaded -= _inventoryModel.OnDataLoad;
        _subscribeManager.UnSubscribe();
    }

    private void OnDestroy()
    {
        UnSubscribe();
    }
}
