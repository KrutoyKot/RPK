using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentInventoryPlayer : MonoBehaviour
{
    [SerializeField] private List<CellEquipInventory> cellsEquip = new List<CellEquipInventory>();

    public void Equip(CellInventory cell)
    {
        var item = cell ? cell.GetItem() : null;
        if (item == null) return;

        //if(item.Type == )
    }
}
