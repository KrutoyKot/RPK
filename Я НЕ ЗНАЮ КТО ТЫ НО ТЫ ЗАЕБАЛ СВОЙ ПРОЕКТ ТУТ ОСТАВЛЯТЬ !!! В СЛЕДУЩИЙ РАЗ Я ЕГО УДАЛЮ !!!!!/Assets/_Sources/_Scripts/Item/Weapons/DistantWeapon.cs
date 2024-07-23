using System.Collections;
using UnityEngine;
using static IUnitMove;

public class DistantWeapon : MonoBehaviour, IDistanceWeapon
{
    [SerializeField] private bool synchronizedShot;
    [SerializeField] private Transform[] shotPoint;

    private float _damage;
    private float _reloadTime;
    private float _lifeTimeBullet;
    private float _speedRotation;
    private float _speedMoveBullet;
    private Camera _camera;

    public float Damage
    {
        get => _damage;
        set => _damage = Mathf.Clamp(value, 0, Mathf.Infinity);
    }
    public float SpeedRotation
    {
        get => _speedRotation;
        set => _speedRotation = Mathf.Clamp(value, 0, Mathf.Infinity);
    }
    public float ReloadTime
    {
        get => _reloadTime;
        set => _reloadTime = Mathf.Clamp(value, 0, Mathf.Infinity);
    }
    public float LifeTimeBullet
    {
        get => _lifeTimeBullet;
        set => _lifeTimeBullet = Mathf.Clamp(value, 0, Mathf.Infinity);
    }
    public float SpeedMoveBullet
    {
        get => _speedMoveBullet;
        set => _speedMoveBullet = Mathf.Clamp(value, 0, Mathf.Infinity);
    }
    public bool IsReload 
    {
        get;
        set;
    }
    public BulletDistanceWeaponBase BulletPrefab
    {
        get;
        set;
    }
    public GameObject WeaponObject
    {
        get => gameObject;
        set => Debug.LogWarningFormat("Cannot assign object");
    }

    private Item _item;

    private void FixedUpdate()
    {
        RotationToTarget();
    }

    public void StartAttack()
    {
        if(IsReload)
        {
            return;
        }
        Shot();
        StartCoroutine(Reload());
    }

    private void Shot()
    {
        var direction = transform.up;
        var point = shotPoint[Random.Range(0, shotPoint.Length)].position;
        var tempBullet = Instantiate(BulletPrefab, point, Quaternion.Euler(direction));
        tempBullet.SetStats(_item, direction);
    }
    public IEnumerator Reload()
    {
        IsReload = true;
        yield return new WaitForSeconds(ReloadTime);
        IsReload = false;
    }

    public void SetStats(Item item)
    {
        Damage = item.Damage;
        ReloadTime = item.ReloadTime;
        SpeedRotation = item.SpeedRotation;
        LifeTimeBullet = item.LifeTimeBullet;
        BulletPrefab = item.BulletPrefab;
        _item = item;
    }

    private void RotationToTarget()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        Vector3 direction = (mousePosition - transform.position).normalized;

        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, direction);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _speedRotation * Time.fixedDeltaTime);
    }


    public void SetCamera(Camera camera)
    {
        _camera = camera;
    }

}
