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

        public void Equip(ICell cell)
        {
            var item = cell != null ? cell.Item : null;
            if (item == null) return;
            if (item.IsEquip == false) return;

            if (item.Type == Item.TypeItem.MeleeWeapon) cellMeleeWeapon.AddItem(item);
            else if (item.Type == Item.TypeItem.DistantWeapon) cellDistantWeapon.AddItem(item);
            else if (item.Type == Item.TypeItem.Helmet) cellHelmet.AddItem(item);
            else if (item.Type == Item.TypeItem.Armor) cellArmor.AddItem(item);
            else if (item.Type == Item.TypeItem.Trousers) cellTrousers.AddItem(item);
            else if (item.Type == Item.TypeItem.Boots) cellBoots.AddItem(item);
        }
    }
}
