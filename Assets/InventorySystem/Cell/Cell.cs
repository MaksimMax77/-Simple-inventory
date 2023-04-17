using System;
using Items;

namespace InventorySystem.Cell
{
    public class Cell
    {
        public event Action<ItemData, bool, bool> CellUpdate;
        public ItemData itemData;
        public int index; 
        public bool occupied;
        public bool available;
        
        public void Take(ItemData itemData)
        {
            this.itemData = itemData;
            occupied = true;
            CellUpdate?.Invoke(itemData, occupied, available);
        }

        public void Release()
        {
            occupied = false;
            itemData = default;
            CellUpdate?.Invoke(itemData, occupied, available);
        }
    }
}
