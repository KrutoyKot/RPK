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

        public void AddItem(ItemHandler item)
        {
            cells[0].AddItem(item.GetItem(), item.GetCount());
        }
    }
}
