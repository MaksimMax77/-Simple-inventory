using System;
using Items;

namespace InventorySystem
{
    [Serializable]
    public class Cell
    {
        public ItemData itemData;
        public int index; 
        public bool occupied;
        public bool available;
        
        public void Take(ItemData itemData)
        {
            this.itemData = itemData;
            occupied = true;
        }

        public void Release()
        {
            occupied = false;
            itemData = default;
        }
    }
}
