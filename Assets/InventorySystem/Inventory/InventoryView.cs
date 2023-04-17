using System;
using InventorySystem.Cell;
using UnityEngine;

namespace InventorySystem.Inventory
{
    public class InventoryView : MonoBehaviour
    {
        public event Action<int, int> NeedSwapCells;
        private CellView[] _cells;
        [SerializeField] private CellView _cellViewPrefab;
        [SerializeField] private Transform _cellParent;
        
        public void OnCellsCreated(int size)
        {
            _cells = new CellView[size];

            for (int i = 0, len = _cells.Length; i < len; ++i)
            {
                var cell = Instantiate(_cellViewPrefab, _cellParent);
                cell.index = i;
                _cells[i] = cell;
                cell.ItemDropped += OnItemDropped;
            }
        }
        
        public void OnUpdate(Cell.Cell cell, bool itemAdd)
        {
            var cellView = _cells[cell.index];
            
            if (itemAdd)
            {
                cellView.UpdateCell(cell.itemData.amount, cell.available, GameManager.Instance.ItemsManager.GetSpriteByIndex(cell.itemData.index));
            }
            else
            {
                cellView.UpdateCell(0, cell.available,null);
            }
        }

        private void OnItemDropped(int droppedIndex, int index)
        {
            NeedSwapCells?.Invoke(droppedIndex, index);
        }

        private void OnDestroy()
        {
            for (int i = 0, len = _cells.Length; i < len; ++i)
            {
                _cells[i].ItemDropped -= OnItemDropped;
            }
        }
    }
}
