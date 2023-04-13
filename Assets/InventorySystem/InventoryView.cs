using Items;
using UnityEngine;

namespace InventorySystem
{
    public class InventoryView : MonoBehaviour
    {
        private CellView[] _cells;
        [SerializeField] private CellView _cellViewPrefab;
        [SerializeField] private Transform _cellParent;

        public void InitCells(int size)
        {
            _cells = new CellView[size];
        }
        
        public void OnCellCreated(int index)
        {
            var cell = Instantiate(_cellViewPrefab, _cellParent);
            _cells[index] = cell;
        }
        
        public void OnUpdate(Cell cell, bool itemAdd)
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
    }
}
