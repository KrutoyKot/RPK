using System;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    [RequireComponent(typeof(Button))]
    public class CellInventory : MonoBehaviour, ICell
    {
        [SerializeField] private Sprite nullSprite;

        public Item Item { get; set; }
        public int CountItem { get; set; }
        public Image CellBackgroundImage { get; set; }
        public Image CellImage { get; set; }
        public Button CellButton { get; set; }

        public bool isEquipment { get; set; }

        private Text _itemCountText;

        private void Start()
        {
            CellButton = GetComponent<Button>();
            InitializationUI();
            CellButton.onClick.AddListener(Select);
        }

        public void AddItem(Item item, int addCount = 1)
        {
            Item = item;
            CountItem += addCount;
            RefreshUI();
        }

        public void Select()
        {
            ICell.OnClickCellEvent?.Invoke(this);
        }

        public void RefreshUI()
        {
            InitializationUI();

            var hasItem = Item != null;

            CellImage.sprite = hasItem ? Item.Sprite : nullSprite;
            _itemCountText.text = hasItem ? $"X{CountItem}" : null;
        }
        public void RemoveItem()
        {
            Item = null;
            CountItem = 0;
            RefreshUI();
        }

        public void InitializationUI()
        {
            if (CellBackgroundImage == null) CellBackgroundImage = GetComponent<Image>();
            if (CellImage == null) CellImage = transform.GetChild(0).GetComponent<Image>();
            if (_itemCountText == null) _itemCountText = transform.GetChild(1).GetComponent<Text>();
        }
    }
}
