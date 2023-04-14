using EventSubscriber;

namespace InventorySystem
{
    public class InventoryController: ISubscriber
    {
        private InventoryModel _inventoryModel;
        private InventoryView _inventoryView;

        public InventoryController(InventoryModel inventoryModel, InventoryView inventoryView)
        {
            _inventoryModel = inventoryModel;
            _inventoryView = inventoryView;
        }

        public void Subscribe()
        {
            _inventoryModel.CellUpdated += _inventoryView.OnUpdate;
            _inventoryModel.CellsCreated += _inventoryView.OnCellsCreated;
        }
        
        public void UnSubscribe()
        {
            _inventoryModel.CellUpdated -= _inventoryView.OnUpdate;
            _inventoryModel.CellsCreated -= _inventoryView.OnCellsCreated;
        }
    }
}
