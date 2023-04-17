using System;
using InventorySystem.Drag;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace InventorySystem.Cell
{
    public class CellView : MonoBehaviour, IDragHandler, IDropHandler, IBeginDragHandler,IEndDragHandler
    {
        public event Action<int, int> ItemDropped;
        public int index;
        [SerializeField] private Image _image;
        [SerializeField] private GameObject _counter;
        [SerializeField] private TextMeshProUGUI  _counterText;
        [SerializeField] private GameObject _closedImage;
        [SerializeField] private DragItem _dragItem;

        public void UpdateCell(int amount, bool available, Sprite sprite)
        {
            _closedImage.SetActive(!available);
            UpdateCounterText(amount);
            _image.enabled = sprite != null;
            _image.sprite = sprite;
            _dragItem.SetImage(sprite);
        }
        
        private void UpdateCounterText(int amount)
        {
            _counter.SetActive(amount > 0);
            _counterText.text = amount.ToString();
        }

        #region drag

        public void OnDrop(PointerEventData eventData)
        {
            var dropCell = eventData.pointerDrag.gameObject.GetComponent<CellView>();
            
            if (dropCell)
            {
                ItemDropped?.Invoke(dropCell.index, index);
            }
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (!_image.enabled)
            {
                return;
            }

            SetDragItem(true, transform.parent);
        }
        
        public void OnDrag(PointerEventData eventData)
        {
            _dragItem.transform.position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            SetDragItem(false, transform);
        }

        private void SetDragItem(bool startDrug, Transform parent)
        {
            _dragItem.ItemImage.raycastTarget = !startDrug;
            _dragItem.gameObject.SetActive(startDrug);
            _dragItem.transform.SetParent(parent);
        }
        
        #endregion
    }
}
