using System.Collections;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    private PlayerControls playerControls;

    [Header("---- Components ----")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private TrailRenderer trailRenderer;
    

    [Header("---- Parameter ----")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashTime;
    [SerializeField] private float dashCountDown;

    private Vector2 movement;
    private bool facingLeft = false;
    private bool isDashing = false;

    public bool FacingLeft
    {
        get => facingLeft;
        set => facingLeft = value;
    }

    protected override void Awake()
    {
        base.Awake();
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    void Start()
    {
        playerControls.Combat.Dash.performed += _ => Dash();
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

    private void Dash()
    {
        if (!isDashing)
        {
            isDashing = true;
            moveSpeed *= dashSpeed;
            trailRenderer.emitting = true;
            StartCoroutine(DashHandler());
        }
    }

    private IEnumerator DashHandler()
    {
        yield return new WaitForSeconds(dashTime);
        moveSpeed /= dashSpeed;
        trailRenderer.emitting = false;
        yield return new WaitForSeconds(dashCountDown - dashTime);
        isDashing = false;
    }
}
