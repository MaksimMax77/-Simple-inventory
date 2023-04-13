using System.Collections.Generic;
using Items.Containers;
using UnityEngine;

namespace Items
{
    public class ItemsManager : MonoBehaviour
    {
        [SerializeField] private List<ItemContainer> _itemContainers = new List<ItemContainer>();
        
        public List<ItemContainer> ItemContainers => _itemContainers;
        
        public List<ItemContainer> GetItemsContainersByItemType(ItemType itemType)
        {
            var bodyItems = new List<ItemContainer>();

            for (int i = 0, len = _itemContainers.Count; i < len; ++i)
            {
                if (_itemContainers[i].ItemType == itemType)
                {
                    bodyItems.Add(_itemContainers[i]);
                }
            }

            return bodyItems;
        }

        public Sprite GetSpriteByIndex(int index)
        {
            return _itemContainers[index].Sprite;
        }

        public int GetContainerIndex(ItemContainer itemContainer)
        {
            return _itemContainers.IndexOf(itemContainer);
        }
        
    }
}
