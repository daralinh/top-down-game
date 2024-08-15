using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerControls playerControls;

    [Header("---- Physical ----")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Vector2 movement;
    private bool facingLeft = false;

    [Header("---- Parameter ----")]
    [SerializeField] private float moveSpeed;
    
    public bool FacingLeft
    {
        get { return facingLeft; }
        set { facingLeft = value; }
    }

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    void Start()
    {
        
    }
    void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        AdjustPlayerFacingDirection();
        Move();
    }

    private void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();

        animator.SetFloat("moveX", movement.x);
        animator.SetFloat("moveY", movement.y);
    }

    private void Move()
    {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

    private void AdjustPlayerFacingDirection()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        if (mousePos.x < playerScreenPoint.x)
        {
            spriteRenderer.flipX = true;
            FacingLeft = true;
        }
        else
        {
            spriteRenderer.flipX = false;
            FacingLeft = false;
        }
    }
}
