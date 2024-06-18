using Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    [RequireComponent(typeof(Button))]
    public class CellEquipInventory : MonoBehaviour, ICell
    {
        [SerializeField] private Sprite nullSprite;

        public Item Item { get; set; }
        public int CountItem { get; set; }
        public Image CellBackgroundImage { get; set; }
        public Image CellImage { get; set; }
        public Button CellButton { get; set; }

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
        }

        public void InitializationUI()
        {
            if (CellBackgroundImage == null) CellBackgroundImage = GetComponent<Image>();
            if (CellImage == null) CellImage = transform.GetChild(0).GetComponent<Image>();
        }
    }
}
