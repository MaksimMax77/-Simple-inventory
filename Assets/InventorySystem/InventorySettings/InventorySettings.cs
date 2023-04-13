using UnityEngine;

namespace InventorySystem.InventorySettings
{
    [CreateAssetMenu(fileName = "InventorySettings", menuName = "InventorySettings", order = 1)]
    public class InventorySettings : ScriptableObject
    {
        [SerializeField] private int _size;
        [SerializeField] private int _freeCellsAmount;
        [SerializeField] private int _buyingCellsAmount;
        [SerializeField] private CellView cellViewPrefab;
        public int Size => _size;
        public int FreeCellsAmount => _freeCellsAmount;
        public int BuyingCellsAmount => _buyingCellsAmount;
    }
}
