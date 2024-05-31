using Player;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PanelInfoItem : MonoBehaviour
{
    [SerializeField] private Image cellItemImage;
    [SerializeField] private Text nameItem;
    [SerializeField] private Text descriptionItem;

    private void OnEnable()
    {
        CellInventory.OnClickCellEvent += ShowInfo;
    }
    private void OnDisable()
    {
        CellInventory.OnClickCellEvent -= ShowInfo;
    }

    private void ShowInfo(CellInventory cell)
    {
        var item = cell.GetItem();
        cellItemImage.sprite = item.Sprite;
        nameItem.text = item.NameItem;
        descriptionItem.text = item.Description;
    }
}
