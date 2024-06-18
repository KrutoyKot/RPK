using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private int coinCount;
        [SerializeField] private Text coinCountText;
        [SerializeField] private List<CellInventory> cells = new List<CellInventory>();

        private int _lastItemRemaions;
        private int _maxItemCountCell = 64;

        private void Start()
        {
            RefreshUI();
        }

        public bool AddItem(Item item, int count = 1)
        {
            int countItem = item.IsStack ? count : 1;

            if (item.Type == Item.TypeItem.Coin)
            {
                coinCount += countItem;
                RefreshUI();
                return true;
            }

            if (item.IsStack)
            {
                for (int i = 0; i < cells.Count; i++)
                {
                    if (item == cells[i].Item)
                    {
                        if (cells[i].CountItem + countItem > _maxItemCountCell)
                        {
                            _lastItemRemaions = cells[i].CountItem + countItem - _maxItemCountCell;
                            cells[i].AddItem(item, countItem - _lastItemRemaions);
                            countItem = _lastItemRemaions;
                            _lastItemRemaions = countItem;
                        }
                        else
                        {
                            cells[i].AddItem(item, countItem);
                            return true;
                        }
                    }
                }
            }

            for (int i = 0; i < cells.Count; i++)
            {
                if (cells[i].Item == false)
                {
                    cells[i].AddItem(item, countItem);
                    return true;
                }
            }

            return false;
        }

        private void RefreshUI()
        {
            coinCountText.text = $"{coinCount}$";
        }
        public int GetLastItemRemaions() => _lastItemRemaions;
    }
}
