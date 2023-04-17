using System;
using System.Collections.Generic;
using Items;
using Items.Containers;
using UnityEngine;
using Random = System.Random;

namespace InventorySystem.Inventory
{
    public class InventoryModel
    {
        public event Action<int> CellsCreated;
        public event Action<Cell.Cell []> InventoryUpdated;
        public event Action<Cell.Cell, bool> CellUpdated;
        
        private Cell.Cell[] _cells;
        private int _size;
        private int _freeCellsAmount;
        private int _buyingCellsAmount;
        
        public InventoryModel(InventorySettings.InventorySettings settings)
        {
            _size = settings.Size;
            _freeCellsAmount = settings.FreeCellsAmount;
            _buyingCellsAmount = settings.BuyingCellsAmount;
        }
        
        #region public functions
        public void OnDataLoad(List<Cell.Cell> loadedCells)
        {
            CreateCellsField();
            
            if (loadedCells == null)
            {
                AddAvailableCells(_freeCellsAmount);
                return;
            }
            
            for (int i = 0, len = loadedCells.Count; i < len; ++i)
            {
                var cell = _cells[loadedCells[i].index] = loadedCells[i];
                
                if (cell.available && cell.occupied)
                {
                    CellUpdated?.Invoke(cell, true);
                }
                else
                {
                    CellUpdated?.Invoke(cell, false);
                }
            }
        }

        public void AddNewItem(ItemData itemData)
        {
            SetInFreeCell(itemData);
            InventoryUpdated?.Invoke(_cells);
        }

        public void RemoveRandomItem()
        {
            var cells = GetOccupiedCells();
            RemoveItem(new Random().Next(cells.Count));
            InventoryUpdated?.Invoke(_cells);
        }

        public void SpendRandomItemByType(ItemType itemType, int value)
        {
            var random = new Random();
            var cells = GetCellsByItemType(itemType);
            if (cells.Count == 0)
            {
                return;
            }

            var index = random.Next(cells.Count);
            var cell = cells[index];
            
            var result = cell.itemData.amount -= value;
            
            if (result == 0)
            {
                RemoveItem(index);
                return;
            }
            CellUpdated?.Invoke(cell, true);
            InventoryUpdated?.Invoke(_cells);
        }

        public void BuyCells()
        {
            AddAvailableCells(_buyingCellsAmount);
        }

        public void SwapCells(int dropIndex, int index)
        { 
            if (!_cells[index].available || !_cells[dropIndex].occupied)
            {
                return;
            }

            (_cells[dropIndex], _cells[index]) = (_cells[index], _cells[dropIndex]);
            _cells[dropIndex].index = dropIndex;
            _cells[index].index = index;
            
            CellUpdated?.Invoke(_cells[dropIndex], _cells[dropIndex].occupied);
            CellUpdated?.Invoke(_cells[index], _cells[index].occupied);
            InventoryUpdated?.Invoke(_cells);
        }

        private void AddAvailableCells(int amount)
        {
            for (int i = 0, len = _cells.Length; i < len; ++i)
            {
                if (amount == 0)
                {
                    return;
                }

                if (_cells[i].available)
                {
                    continue;
                }
                _cells[i].available = true;
                CellUpdated?.Invoke(_cells[i], _cells[i].occupied);
                --amount;
            }
            InventoryUpdated?.Invoke(_cells);
        }
        
        private void CreateCellsField()
        {
            _cells = new Cell.Cell[_size];

            for (int i = 0, len = _cells.Length ; i < len; ++i)
            {
                var cell = new Cell.Cell();
                _cells[i] = cell;
                cell.index = i;
            }
            CellsCreated?.Invoke(_size);
        }
        
        private void SetInFreeCell(ItemData itemData)
        {
            for (int i = 0, len = _cells.Length; i < len; ++i)
            {
                if (_cells[i].occupied || !_cells[i].available)
                {
                    continue;
                }
                
                _cells[i].Take(itemData);
                CellUpdated?.Invoke(_cells[i], true);
                return;
            }
        }

        private List<Cell.Cell> GetOccupiedCells()
        {
            var cells = new List<Cell.Cell>();

            for (int i = 0, len = _cells.Length; i < len; ++i)
            {
                if (_cells[i].occupied)
                {
                    cells.Add(_cells[i]);
                }
            }
            
            return cells;
        }

        private List<Cell.Cell> GetCellsByItemType(ItemType itemType)
        {
            var cells = new List<Cell.Cell>();
            var occupiedCells = GetOccupiedCells();
            
            for (int i = 0, len = occupiedCells.Count; i < len; ++i)
            {
                if (occupiedCells[i].itemData.itemType != itemType)
                {
                    continue;
                }
                cells.Add(occupiedCells[i]);
            }

            return cells;
        }

        private void RemoveItem(int index)
        {
            var cells = GetOccupiedCells();
            
            if (cells.Count == 0)
            {
                Debug.LogError("NO ITEMS");
                return;
            }
            
            var cell = cells[index];
            cell.Release();
            CellUpdated?.Invoke(cell, false);
        }
        
        #endregion
    }
}
