using EventSubscriber;
using InventorySystem;
using Items;
using Items.Containers;
using Random = System.Random;

namespace GameWindow
{
    public class GameWindowController: ISubscriber
    {
        private InventoryModel _inventoryModel;
        private GameWindowView _gameWindowView;
        private ItemsManager _itemsManager ;

        public GameWindowController(InventoryModel model, GameWindowView gameWindowView, ItemsManager itemsManager)
        {
            _inventoryModel = model;
            _gameWindowView = gameWindowView;
            _itemsManager = itemsManager;
        }

        public void Subscribe()
        {
            _gameWindowView.AddBulletsButtonClicked += CreateBullets;
            _gameWindowView.AddItemButtonClicked += AddRandomItemOfEachType;
            _gameWindowView.RemoveButtonClicked += RemoveRandomItem;
            _gameWindowView.ShootButtonClicked += Shoot;
            _gameWindowView.BuyMoreCellsButtonClicked += BuyMoreCells;
        }

        public void UnSubscribe()
        {
            _gameWindowView.AddBulletsButtonClicked -= CreateBullets;
            _gameWindowView.AddItemButtonClicked -= AddRandomItemOfEachType;
            _gameWindowView.RemoveButtonClicked -= RemoveRandomItem;
            _gameWindowView.ShootButtonClicked -= Shoot;
            _gameWindowView.BuyMoreCellsButtonClicked -= BuyMoreCells;
        }

        private void CreateBullets()
        {
            for (int i = 0, len = _itemsManager.ItemContainers.Count; i < len; ++i)
            {
                if (_itemsManager.ItemContainers[i].ItemType == ItemType.Bullet)
                {
                    _inventoryModel.AddNewItem(CreateItemData(_itemsManager.ItemContainers[i], i));
                }
            }
        }

        private void AddRandomItemOfEachType()
        {
            CreateRandomItem(ItemType.HeadItem);
            CreateRandomItem(ItemType.BodyItem);
            CreateRandomItem(ItemType.Weapon);
        }

        private void RemoveRandomItem()
        {
            _inventoryModel.RemoveRandomItem();
        }

        private void CreateRandomItem(ItemType itemType)
        {
            var random = new Random();
            var itemContainers = _itemsManager.GetItemsContainersByItemType(itemType);
            var itemContainer = itemContainers[random.Next(itemContainers.Count)];
            _inventoryModel.AddNewItem(CreateItemData(itemContainer, _itemsManager.GetContainerIndex(itemContainer)));
        }

        private void Shoot()
        {
            _inventoryModel.SpendRandomItemByType(ItemType.Bullet, 1);
        }

        private ItemData CreateItemData(ItemContainer itemContainer, int index)
        {
            var itemData = new ItemData
            {
                itemType = itemContainer.ItemType,
                index = index,
                weight = itemContainer.Weight,
                amount = itemContainer.AmountInStack
            };
            return itemData;
        }

        private void BuyMoreCells()
        {
            _inventoryModel.BuyCells();
        }
    }
}
