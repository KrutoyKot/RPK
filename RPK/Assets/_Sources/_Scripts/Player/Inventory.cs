using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private List<CellInventory> cells = new List<CellInventory>();

        public int ostatok;

        private int _lastItemRemanions;
        private int maxItemCountCells = 64;

        private void Start()
        {

        }

        public bool AddItem(Item item, int count = 1)
        {
            int countItem = item.IsStack ? count : 1;

            if (item.IsStack)
            {
                for (int i = 0; i < cells.Count; i++)
                {
                    if (item == cells[i].GetItem())
                    {
                        var max = cells[i].GetCount() + count;
                        if (max > maxItemCountCells)
                        {
                            _lastItemRemanions = max - maxItemCountCells;
                            cells[i].SetCount(maxItemCountCells);
                            countItem = _lastItemRemanions;
                            _lastItemRemanions = countItem;
                        }
                        else
                        {
                            cells[i].AddItem(item, count);
                            return true;
                        }
                    }
                }
            }
            for (int i = 0; i < cells.Count; i++)
            {
                if (cells[i].HasItem() == false)
                {
                    cells[i].AddItem(item, count);
                    return true;
                }
            }

            return false;
        }
        public int GetLastRemations()
        {
            return _lastItemRemanions;
        }
    }
}
