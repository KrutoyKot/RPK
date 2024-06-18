using Player;
using UnityEngine;
using UnityEngine.UI;

public class PanelInfoItem : MonoBehaviour
{
    [SerializeField] private Sprite spriteNull;
    [SerializeField] private Image cellItemImage;
    [SerializeField] private Text nameItem;
    [SerializeField] private Text descriptionItem;
    [Space]
    [SerializeField] private Button dropItemButton;
    [SerializeField] private Button useItemButton;
    [SerializeField] private Button sellItemButton;
    [SerializeField] private Button takeOffItemButton;
    [Space]
    [SerializeField] private EquipmentInventoryPlayer equipment;

    private ICell _lastSelectCell;

    private void OnEnable()
    {
        ICell.OnClickCellEvent += ShowInfo;
    }

    private void OnDisable()
    {
        ICell.OnClickCellEvent -= ShowInfo;
    }

    private void Start()
    {
        RefreshUI();
        useItemButton.onClick.AddListener(Use);
        dropItemButton.onClick.AddListener(Drop);
        sellItemButton.onClick.AddListener(Sell);
    }

    public void Use()
    {
        if (_lastSelectCell == null) return;
        if (_lastSelectCell.Item == null) return;

        var item = _lastSelectCell.Item;

        if (item.Type == Item.TypeItem.Recovery)
        {
            //Add HP
        }
        else if (item.IsEquip)
        {
            equipment.Equip(_lastSelectCell);
        }
    }

    public void Drop()
    {

    }

    public void Sell()
    {

    }

    private void ShowInfo(ICell cell)
    {
        var tempCell = _lastSelectCell == cell ? null : cell;
        _lastSelectCell = tempCell;
        RefreshUI(tempCell);
    }

    private void RefreshUI(ICell cell = null)
    {
        var item = cell != null ? cell.Item : null;
        cellItemImage.sprite = item ? item.Sprite : spriteNull;
        nameItem.text = item ? item.NameItem : "Name Item";
        descriptionItem.text = item ? item.Description : "Click on a cell";

        dropItemButton.interactable = item;
        useItemButton.interactable = item;
        sellItemButton.interactable = item;
    }
}
