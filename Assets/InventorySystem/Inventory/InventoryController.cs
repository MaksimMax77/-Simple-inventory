using EventSubscriber;

namespace InventorySystem.Inventory
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
            _inventoryView.NeedSwapCells += _inventoryModel.SwapCells;
        }
        
        public void UnSubscribe()
        {
            _inventoryModel.CellUpdated -= _inventoryView.OnUpdate;
            _inventoryModel.CellsCreated -= _inventoryView.OnCellsCreated;
            _inventoryView.NeedSwapCells -= _inventoryModel.SwapCells;
        }
    }
}
