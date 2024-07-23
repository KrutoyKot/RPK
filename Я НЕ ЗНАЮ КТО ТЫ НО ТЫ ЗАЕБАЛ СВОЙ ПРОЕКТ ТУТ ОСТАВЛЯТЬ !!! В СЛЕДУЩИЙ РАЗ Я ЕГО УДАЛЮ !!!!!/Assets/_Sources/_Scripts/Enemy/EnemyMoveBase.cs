using UnityEngine;

public class EnemyMoveBase : MonoBehaviour, IUnitMove
{
    [SerializeField] private float radiusAgressive;
    [SerializeField] private float radiusPatrolling;
    [SerializeField] private float radiusPreparingAttack;
    [SerializeField] private float radiusAttack;
    [Space]
    [SerializeField] private float speedMove;
    [SerializeField] private float speedMovePreparingAttack;
    [SerializeField] private float speedMoveAttack;
    [Space]
    [SerializeField] private LayerMask layerPlayer;
    [SerializeField] private LayerMask layerWall;
    public float SpeedMove
    {
        get => speedMove;
        set => speedMove = Mathf.Clamp(value, 0, Mathf.Infinity);
    }
    public float SpeedMovePreparingAttack
    {
        get => speedMovePreparingAttack;
        set => speedMovePreparingAttack = Mathf.Clamp(value, 0, Mathf.Infinity);
    }
    public float SpeedMoveAttack
    {
        get => speedMoveAttack;
        set => speedMoveAttack = Mathf.Clamp(value, 0, Mathf.Infinity);
    }

    private void Start()
    {

    }

    private void FixedUpdate()
    {
        Collider2D player = Physics2D.OverlapCircle(transform.position, radiusAgressive, layerPlayer);


        if(player)
        {
            Attack(player.transform);
        }
    }

    private void Attack( Transform player)
    {
        if(Vector2.Distance(transform.position, player.position) > radiusPreparingAttack)
        {
            Move(player.position);
        }
        else
        {
            //startattack
        }
    }

    public void Move(Vector2 direction)
    {
        transform.position = Vector2.MoveTowards(transform.position, direction, speedMove * Time.fixedDeltaTime);
    }
}
