using System;
using System.Collections.Generic;
using InventorySystem.Cell;

namespace DataProvider
{
    public class InventoryDataProvider
    {
        public event Action<List<Cell>> DataLoaded; 
        private const string _directory = "/SaveData/";
        private const string _fileName = "GameData.json";

        public void OnInventoryUpdated(Cell[] cells)
        {
            Saver.SaveData(cells, _directory, _fileName);
        }

        public void LoadData()
        {
            var cells = Saver.LoadData<List<Cell>>(_directory, _fileName);
            DataLoaded?.Invoke(cells);
        }
    }
}
