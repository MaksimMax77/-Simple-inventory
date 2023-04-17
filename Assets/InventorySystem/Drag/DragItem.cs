using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem.Drag
{
    public class DragItem : MonoBehaviour
    {
        public Image ItemImage;

        public void SetImage(Sprite sprite)
        {
            ItemImage.sprite = sprite;
        }
    }
}
