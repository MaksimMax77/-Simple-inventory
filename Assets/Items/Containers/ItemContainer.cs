using UnityEngine;

namespace Items.Containers
{
    public enum ItemType
    {
        none,
        HeadItem,
        BodyItem,
        Weapon,
        Bullet
    }
    
    [CreateAssetMenu(fileName = "ItemsContainer", menuName = "ItemsContainer", order = 2)]
    public class ItemContainer : ScriptableObject
    {
        [SerializeField] protected Sprite _sprite;
        [SerializeField] protected float _weight;
        [SerializeField] private ItemType _itemType;
        [SerializeField] private int _amountInStack;

        public Sprite Sprite => _sprite;
        public float Weight => _weight;
        public ItemType ItemType => _itemType;

        public int AmountInStack => _amountInStack;
    }
}
