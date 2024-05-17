using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class CellInventory : MonoBehaviour
    {
        [SerializeField] private Sprite nullSprite;
        private Item _item;
        private int _count;

        private Image _cellBackGroundImage;
        private Image _cellImage;
        private Text _itemCountText;
        private void Start()
        {
            InitilizationUI();
        }

        public void AddItem(Item item, int addCount)
        {
            _item = item;
            _count += addCount;
            RefreshUI();
        }
        public bool HasItem()
        {
            return _item;
        }
        public Item GetItem()
        {
            return _item;
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
