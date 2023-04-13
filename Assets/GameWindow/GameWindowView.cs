using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameWindow
{
    public class GameWindowView : MonoBehaviour
    {
        public event Action ShootButtonClicked;
        public event Action AddBulletsButtonClicked;
        public event Action AddItemButtonClicked;
        public event Action RemoveButtonClicked;
        public event Action BuyMoreCellsButtonClicked;
        
        [SerializeField] private Button _shootButton; 
        [SerializeField] private Button _addBulletsButton; 
        [SerializeField] private Button _addItemButton; 
        [SerializeField] private Button _removeButton;
        [SerializeField] private Button _buyMoreCells;

        private void Awake()
        {
            _shootButton.onClick.AddListener(OnShootButtonClick);
            _addBulletsButton.onClick.AddListener(OnAddBulletsButtonClick);
            _addItemButton.onClick.AddListener(OnAddItemButtonClick);
            _removeButton.onClick.AddListener(OnRemoveButtonClick);
            _buyMoreCells.onClick.AddListener(OnBuyMoreCellsButtonClick);
        }

        private void OnDestroy()
        {
            _shootButton.onClick.RemoveListener(OnShootButtonClick);
            _addBulletsButton.onClick.RemoveListener(OnAddBulletsButtonClick);
            _addItemButton.onClick.RemoveListener(OnAddItemButtonClick);
            _removeButton.onClick.RemoveListener(OnRemoveButtonClick);
            _buyMoreCells.onClick.RemoveListener(OnBuyMoreCellsButtonClick);
        }

        private void OnShootButtonClick()
        {
            ShootButtonClicked?.Invoke();
        }
        
        private void OnAddBulletsButtonClick()
        {
            AddBulletsButtonClicked?.Invoke();
        }
        
        private void OnAddItemButtonClick()
        {
            AddItemButtonClicked?.Invoke();
        }
        
        private void OnRemoveButtonClick()
        {
            RemoveButtonClicked?.Invoke();
        }
        
        private void OnBuyMoreCellsButtonClick()
        {
            BuyMoreCellsButtonClicked?.Invoke();
        }
    }
}
