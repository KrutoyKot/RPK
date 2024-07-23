using Player;
using Unity.VisualScripting;
using UnityEngine;
using static IUnitMove;

public class PlayerAttacking : MonoBehaviour
{
    [SerializeField] private Transform pivotWeaponOne;
    [SerializeField] private Transform pivotWeaponTwo;
    [Space]
    [SerializeField] private Camera cameraPlayer;
    [SerializeField] private EquipmentInventoryPlayer equipment;


    private IWeapon _weaponOne;
    private IWeapon _weaponTwo;

    private void OnEnable()
    {
        equipment.EquipEvent += SetWeapon;
    }
    private void OnDisable()
    {
        equipment.EquipEvent -= SetWeapon;
    }
    private void SetWeapon(ICell cell)
    {
        var item = cell.Item;
        if (item.Type == Item.TypeItem.MeleeWeapon) SetWeaponOne(item);
        else if (item.Type == Item.TypeItem.DistantWeapon) SetWeaponTwo(item);
    }
    private void SetWeaponOne(Item item)
    {
        _weaponOne = SpawnWeapon(item, pivotWeaponOne);
    }
    private void SetWeaponTwo(Item item)
    {
        _weaponTwo = SpawnWeapon(item, pivotWeaponTwo);
        if (_weaponTwo.WeaponObject.TryGetComponent(out IDistanceWeapon distanceWeapon)) distanceWeapon.SetCamera(cameraPlayer);
    }
    private IWeapon SpawnWeapon(Item item, Transform position)
    {
        var temp = Instantiate(item.PrefabWeapon, position);
        temp.transform.position = position.position;
        var weapon = temp.GetComponent<IWeapon>();
        weapon.SetStats(item);
        return weapon;
    }
    public void TakeOff(ICell cell)
    {
        if (cell == null) return;
        var tempItem = cell.Item;

        if (tempItem.Type == Item.TypeItem.MeleeWeapon) DestroyWeapon(_weaponOne);
        if (tempItem.Type == Item.TypeItem.DistantWeapon) DestroyWeapon(_weaponTwo);
    }

    private void Update()
    {
        bool shift = Input.GetKey(KeyCode.LeftShift);

        if (shift)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (_weaponTwo != null)
                    _weaponTwo.StartAttack();
            }

            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (_weaponOne != null)
                _weaponOne.StartAttack();
        }
    }

    private void DestroyWeapon(IWeapon weapon)
    {
        Destroy(weapon.WeaponObject);
    }
}
