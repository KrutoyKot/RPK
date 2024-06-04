using Player;
using UnityEngine;
using UnityEngine.UI;

public class PanelInfoItem : MonoBehaviour
{
    [SerializeField] private Sprite spriteNull;
    [SerializeField] private Image cellItemImage;
    [SerializeField] private Text nameItem;
    [SerializeField] private Text descriptionItem;

    private CellInventory _lastSelectCell;
    private void OnEnable()
    {
        CellInventory.OnClickCellEvent += ShowInfo;
    }
    private void OnDisable()
    {
        CellInventory.OnClickCellEvent -= ShowInfo;
    }

    private void Start()
    {
        RefreshUI(null);
    }
    private void ShowInfo(CellInventory cell)
    {
        var tempCell = _lastSelectCell == cell ? null : cell;
        _lastSelectCell = tempCell;
        RefreshUI(tempCell);
    }

    private void RefreshUI(CellInventory cell = null)
    {
        var item = cell ? cell.GetItem() : null;
        cellItemImage.sprite = item ? item.Sprite : spriteNull;
        nameItem.text = item ? item.NameItem : "Имя предмета";
        descriptionItem.text = item ? item.Description : "Нажми на предмет";
    }
}
