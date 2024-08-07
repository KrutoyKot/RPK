using UnityEngine;

[CreateAssetMenu(menuName = "Item", fileName = "Item")]
public class Item : ScriptableObject
{
    [Header("Main")]
    [SerializeField] private Sprite sprite;
    [SerializeField] private bool isStack;
    [SerializeField] private bool isEquip;
    [SerializeField] private TypeItem type;
    public int addCount;
    [Header("Weapon")]
    [SerializeField] private float damage;
    [SerializeField] private float speedAttack;
    [SerializeField] private GameObject prefabWeapon;
    [Header("DistantWeapon")]
    [SerializeField] private float reloadTime;
    [SerializeField] private float lifeTimeBullet;
    [SerializeField] private float speedRotation;
    [SerializeField] private float speedMoveBullet;
    [SerializeField] private BulletDistanceWeaponBase bulletPrefab;
    [Header("Protection")]
    [SerializeField] private float addSpeed;
    [SerializeField] private float addEndurance;
    [SerializeField] private float addProtection;
    [SerializeField] private float addMana;
    [Header("Recovery")]
    [SerializeField] private float healthRecovery;
    [SerializeField] private float enduranceRecovery;
    [SerializeField] private float manaRecovery;
    [Space]
    [Header("Info")]
    [SerializeField] private string nameItem = "Item";
    [SerializeField, TextArea (8,8)] private string description = "No description";


    public enum TypeItem
    {
        Coin = 0,
        MeleeWeapon = 1,
        DistantWeapon = 2,

        Helmet = 3,
        Armor = 4,
        Trousers = 5,
        Boots = 6,
        gloves = 7,

        Recovery = 8,
        Magic = 9
    }

    public Sprite Sprite => sprite;
    public bool IsStack => isStack;
    public bool IsEquip => isEquip;
    public TypeItem Type => type;

    public float Damage => damage;
    public float SpeedAttack => speedAttack;

    public BulletDistanceWeaponBase BulletPrefab => bulletPrefab;
    public float ReloadTime => reloadTime;
    public float LifeTimeBullet => lifeTimeBullet;
    public float SpeedRotation => speedRotation;
    public float SpeedMoveBullet => speedMoveBullet;
    public GameObject PrefabWeapon => prefabWeapon;

    public float AddProtection => addProtection;
    public float AddEndurance => addEndurance;
    public float AddMana => addMana;
    public float AddSpeed => addSpeed;

    public float HealthRecovery => healthRecovery;
    public float ManaRecovery => manaRecovery;
    public float EnduranceRecovery => enduranceRecovery;

    public string NameItem => nameItem;

    public string Description => description;
}
