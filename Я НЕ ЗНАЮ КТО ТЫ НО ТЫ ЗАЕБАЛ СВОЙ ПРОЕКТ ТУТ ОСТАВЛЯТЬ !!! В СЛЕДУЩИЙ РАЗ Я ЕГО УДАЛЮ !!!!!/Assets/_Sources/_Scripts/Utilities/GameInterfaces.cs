using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface ICell
{
    public Item Item { get; set; }
    public int CountItem { get; set; }
    public Image CellBackgroundImage { get; set; }
    public Image CellImage { get; set; }
    public Button CellButton { get; set; }
    public static Action<ICell> OnClickCellEvent;

    public void AddItem(Item item, int addCount);
    public void Select();
    public void RefreshUI();
    public void InitializationUI();
}
