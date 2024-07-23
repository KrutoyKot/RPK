using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Player
{
    public class EquipmentInventoryPlayer : MonoBehaviour
    {
        [SerializeField] private CellEquipInventory cellMeleeWeapon;
        [SerializeField] private CellEquipInventory cellDistantWeapon;
        [SerializeField] private CellEquipInventory cellHelmet;
        [SerializeField] private CellEquipInventory cellArmor;
        [SerializeField] private CellEquipInventory cellTrousers;
        [SerializeField] private CellEquipInventory cellBoots;

        [SerializeField] private Inventory inventory;

        public Action<ICell> EquipEvent;

        public void Equip(ICell cell)
        {
            var item = cell != null ? cell.Item : null;
            if (item == null) return;
            if (item.IsEquip == false) return;

            ICell lastcell = null;
            Item lastitem = null;

            EquipEvent.Invoke(cell);

            if (item.Type == Item.TypeItem.MeleeWeapon) lastcell = cellMeleeWeapon;            
            else if (item.Type == Item.TypeItem.DistantWeapon) lastcell = cellDistantWeapon;
            else if (item.Type == Item.TypeItem.Helmet) lastcell = cellHelmet;
            else if (item.Type == Item.TypeItem.Armor) lastcell = cellArmor;
            else if (item.Type == Item.TypeItem.Trousers) lastcell = cellTrousers;
            else if (item.Type == Item.TypeItem.Boots) lastcell = cellBoots;

            cell.RemoveItem();

            if(CheckItemCell(lastcell))
            {
                lastitem = lastcell.Item;
                inventory.AddItem(lastitem);
            }

            lastcell.AddItem(item, 1);
        }

        private void DestroyWeapon(IWeapon weapon)
        {
            Destroy(weapon.WeaponObject);
        }
        private bool CheckItemCell(ICell cell)
        {
            return cell.Item;
        }
    }
}
