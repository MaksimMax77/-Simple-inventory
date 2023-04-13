using EventSubscriber;

namespace InventorySystem
{
    public class InventoryController: ISubscriber
    {
        private InventoryModel _inventoryModel;
        private InventoryView _inventoryView;

        public InventoryController(InventoryModel inventoryModel, InventoryView inventoryView, InventorySettings.InventorySettings settings)
        {
            _inventoryModel = inventoryModel;
            _inventoryView = inventoryView;
            _inventoryView.InitCells(settings.Size);
        }

        public void Subscribe()
        {
            _inventoryModel.CellCreated += _inventoryView.OnCellCreated;
            _inventoryModel.CellUpdated += _inventoryView.OnUpdate;
        }
        
        public void UnSubscribe()
        {
            _inventoryModel.CellCreated -= _inventoryView.OnCellCreated;
            _inventoryModel.CellUpdated -= _inventoryView.OnUpdate;
        }
    }
}
