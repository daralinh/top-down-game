using UnityEngine;

public class RoamingNoneTarget : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private Vector2 moveDir;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ChooseRandomMove();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDir * (speed * Time.fixedDeltaTime));
    }

    public void ChooseRandomMove()
    {
        moveDir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}
