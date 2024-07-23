using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletDistanceWeaponBase : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;

    private float _damage;
    private float _speedMove;
    private float _lifeTime;
    private Vector2 _directionMove;

    private void FixedUpdate()
    {
        if (rigidbody) rigidbody.velocity = _directionMove * _speedMove * Time.fixedDeltaTime;
    }

    public virtual void SetStats(Item weaponItem, Vector2 directionMove)
    {
        _damage = weaponItem.Damage;
        _speedMove = weaponItem.SpeedMoveBullet;
        _lifeTime = weaponItem.LifeTimeBullet;
        _directionMove = directionMove;

        if(rigidbody == null) rigidbody = GetComponent<Rigidbody2D>();

        Destroy(gameObject, _lifeTime);
    }
}
