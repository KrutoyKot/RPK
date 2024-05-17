using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private List<CellInventory> cells = new List<CellInventory>();

        private void Start()
        {

        }

        public void AddItem(Item item, int count = 1)
        {
            for (int i = 0; i < cells.Count; i++)
            {
                if (cells[i].HasItem() == false)
                {
                    cells[i].AddItem(item, count);
                    return;
                }
            }
        }
    }
}
