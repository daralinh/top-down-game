using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    [SerializeField] private float originSpeed;

    private float speed;
    private Rigidbody2D rb;
    private Vector2 moveDir;

    public float Speed => speed;
    public float OriginSpeed => originSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = originSpeed;
        ChooseRandomMove();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDir * (speed * Time.fixedDeltaTime));
    }

    public void ChangeSpeed(float newSpeed)
    {
        speed = Mathf.Max(0, newSpeed);
    }

    public void BuffSpeed(float buffToSpeed)
    {
        speed += buffToSpeed;
    }

    public void ChangeSpeedToZero()
    {
        speed = 0;
    }

    public void BackToOriginSpeed()
    {
        speed = originSpeed;
    }

    public void ChooseRandomMove()
    {
        moveDir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    public void ChooseTargetDirecion(Vector2 directionTarget)
    {
        moveDir = directionTarget;
    }

    public Vector2 GetMoveDirection()
    {
        return moveDir;
    }
}
