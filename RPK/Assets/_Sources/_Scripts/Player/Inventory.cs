using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private List<CellInventory> cells = new List<CellInventory>();

        public int ostatok;

        private int maxItemCountCells = 64;

        private void Start()
        {

        }

        public bool AddItem(Item item, int count = 1)
        {
            if (item.IsStack)
            {
                for (int i = 0; i < cells.Count; i++)
                {
                    var max = cells[i].GetCount() + count;
                    if (item == cells[i].GetItem())
                    {
                        if (max > maxItemCountCells)
                        {
                            ostatok = max - maxItemCountCells;
                            cells[i].SetCount(maxItemCountCells);
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
    }
}
