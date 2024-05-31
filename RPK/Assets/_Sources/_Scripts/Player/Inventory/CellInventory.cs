using System;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    [RequireComponent(typeof(Button))]
    public class CellInventory : MonoBehaviour
    {
        [SerializeField] private Sprite nullSprite;
        private Item _item;
        private int _count;

        private Image _cellBackGroundImage;
        private Image _cellImage;
        private Text _itemCountText;
        private Button _cellButton;

        public static Action<CellInventory> OnClickCellEvent;
        private void Start()
        {
            _cellButton = GetComponent<Button>();
            InitilizationUI();

            _cellButton.onClick.AddListener(Select);
        }

        public void AddItem(Item item, int addCount)
        {
            _item = item;
            _count += addCount;
            RefreshUI();
        }
        public void Select()
        {
            OnClickCellEvent?.Invoke(this);
        }
        public bool HasItem()
        {
            return _item;
        }
        public Item GetItem()
        {
            return _item;
        }
        public int GetCount()
        {
            return _count;
        }
        public void SetCount(int countItem)
        {
            _count = countItem;
            RefreshUI();
        }
        private void RefreshUI()
        {
            InitilizationUI();

            var hasItem = HasItem();

            _cellImage.sprite = hasItem ? _item.Sprite : nullSprite;
            _itemCountText.text = hasItem ? $"X{_count}" : null;
        }
        private void InitilizationUI()
        {
            if(_cellBackGroundImage == null) _cellBackGroundImage = GetComponent<Image>();
            if(_cellImage == null) _cellImage = transform.GetChild(0).GetComponent<Image>();
            if(_itemCountText == null) _itemCountText = transform.GetChild(1).GetComponent<Text>();
        }
    }
}
