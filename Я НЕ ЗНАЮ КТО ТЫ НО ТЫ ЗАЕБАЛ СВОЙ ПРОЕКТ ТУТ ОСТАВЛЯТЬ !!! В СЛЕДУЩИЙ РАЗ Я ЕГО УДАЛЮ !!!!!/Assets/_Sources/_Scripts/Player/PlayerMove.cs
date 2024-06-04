using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speedWalk;
    [SerializeField] private float rotationSpeed;

    [SerializeField] private Camera cameraMain;

    private Rigidbody2D _RB;
    private Vector2 startScale;

    public float InputX { get; private set; }
    public float InputY { get; private set; }

    private void Start()
    {
        _RB = GetComponent<Rigidbody2D>();

        startScale = transform.localScale;
    }
    private void FixedUpdate()
    {
        Move();
        Rotation();
    }
    private void Move()
    {
        InputX = Input.GetAxis("Horizontal");
        InputY = Input.GetAxis("Vertical");

        SetVelocity(new Vector2(InputX, InputY) * GetSpeed());
        SetRotationZ(InputX * -rotationSpeed);
    }
    private void Rotation()
    {
        var mousePosition = cameraMain.ScreenToWorldPoint(Input.mousePosition);
        float scaleX = mousePosition.x > transform.position.x ? startScale.x : -startScale.x;
        SetScale(scaleX, startScale.y);
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
    private void SetScale(float X, float Y)
    {
        transform.localScale = new Vector3(X, Y, 1);
    }
    private void SetRotation(float x, float y, float z)
    {
        transform.rotation = Quaternion.Euler(new Vector3(x, y, z));
    }
}
