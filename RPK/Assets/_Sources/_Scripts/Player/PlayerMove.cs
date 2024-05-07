using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speedWalk;
    [SerializeField] private float rotationSpeed;

    private Rigidbody2D _RB;

    public float InputX { get; private set; }
    public float InputY { get; private set; }

    private void Start()
    {
        _RB = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        InputX = Input.GetAxis("Horizontal") * speedWalk * Time.fixedDeltaTime;
        InputY = Input.GetAxis("Vecrtical") * speedWalk * Time.fixedDeltaTime;

        SetVelocity(new Vector2(InputX, InputY) * GetSpeed());
        SetRotationZ(InputX * -rotationSpeed);
    }
    private float GetSpeed()
    {
        return speedWalk * Time.fixedDeltaTime;
    }
    public void SetVelocity(float x, float y)
    {
        SetVelocity(new Vector2(x, y));
    }    
    public void SetVelocity(Vector2 direction)
    {
       _RB.velocity = direction;
    }

    private void SetRotationZ(float z)
    {
        SetRotation(0, 0, z);
    }    
    private void SetRotation(float x, float y, float z)
    {
        transform.rotation = Quaternion.Euler(new Vector3(x, y, z));
    }
}
