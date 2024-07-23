using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class MeleeWeapon : MonoBehaviour, IMeleeWeapon
{
    private float damage;
    private float speedAttack;
    private string _attackNameAnimation = "Attack";
    private Animator _animator;

    public float Damage
    {
        get => damage;
        set => Mathf.Clamp(value, 0, Mathf.Infinity);
    }

    public float SpeedAttack
    {
        get => speedAttack;
        set => Mathf.Clamp(value, 0.1f, Mathf.Infinity);
    }

    public GameObject WeaponObject
    {
        get => gameObject;
        set => Debug.LogWarningFormat("Cannot assign object");
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void StartAttack()
    {
        if (_animator == null) return;

        
        _animator.SetTrigger(_attackNameAnimation);
        _animator.speed = SpeedAttack;
    }
    public void SetStats(Item item)
    {
        Damage = item.Damage;
        SpeedAttack = item.SpeedAttack;
    }
}
