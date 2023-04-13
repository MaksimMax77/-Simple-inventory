using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem
{
    public class CellView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private GameObject _counter;
        [SerializeField] private TextMeshProUGUI  _counterText;
        [SerializeField] private GameObject _closedImage;
        
        public void UpdateCell(int amount, bool available, Sprite sprite)
        {
            _closedImage.SetActive(!available);
            UpdateCounterText(amount);
            _image.enabled = sprite != null;
            _image.sprite = sprite;
        }
        private void UpdateCounterText(int amount)
        {
            _counter.SetActive(amount > 0);
            _counterText.text = amount.ToString();
        }
    }
}
