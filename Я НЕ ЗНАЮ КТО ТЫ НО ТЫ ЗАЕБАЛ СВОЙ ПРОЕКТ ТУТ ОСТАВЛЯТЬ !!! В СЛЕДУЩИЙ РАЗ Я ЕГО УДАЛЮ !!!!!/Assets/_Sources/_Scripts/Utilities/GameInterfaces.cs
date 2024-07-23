using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IUnitMove
{
    public float SpeedMove { get; set; }
    public void Move(Vector2 direction);

}
public interface IWeapon
{
    public float Damage { get; set; }
    public GameObject WeaponObject {  get; set; }

    public void StartAttack();
    public void SetStats(Item item);

}
public interface IMeleeWeapon : IWeapon
{
    public float SpeedAttack { get; set; }
}
public interface IDistanceWeapon : IWeapon
{
    public float SpeedRotation { get; set; }
    public float ReloadTime { get; set; }
    public float LifeTimeBullet { get; set; }
    public float SpeedMoveBullet {  get; set; }
    public bool IsReload { get; set; }
    public IEnumerator Reload();
    public BulletDistanceWeaponBase BulletPrefab { get; set; }
    public void SetCamera(Camera camera);
}
    public interface ICell
    {
        public Item Item { get; set; }
        public int CountItem { get; set; }
        public Image CellBackgroundImage { get; set; }
        public Image CellImage { get; set; }
        public Button CellButton { get; set; }
        public bool isEquipment { get; set; }
        public static Action<ICell> OnClickCellEvent;

        public void AddItem(Item item, int addCount);
        public void Select();
        public void RefreshUI();
        public void InitializationUI();
        public void RemoveItem();

    }
