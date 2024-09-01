using UnityEngine;

[RequireComponent(typeof(MoveToTarget))]
[RequireComponent(typeof(HpForEmeny))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]

public abstract class AEnemy : MonoBehaviour
{
    [Header("Set origin speed in Component MoveToTarget")]
    [SerializeField] protected float speedWhenChasing;
    [SerializeField] protected GameObject deathVFXGameObject;
    [SerializeField] protected float timeToChangeDirectionWhenRoaming;

    protected IStateEnemy stateCurrent;
    protected IStateEnemy roamState;
    protected IStateEnemy chasingPlayerState;
    protected IStateEnemy aTKState;
    protected IStateEnemy deathState;

    protected SpriteRenderer spriteRenderer;
    protected HpForEmeny hpForEmeny;
    protected Animator animator;
    protected MoveToTarget moveToTarget;
    protected Rigidbody2D rb;

    protected bool isFacingLeft;
    protected GameObject myDeathVFX;

    public float TimeToChangeDirectionWhenRoaming => timeToChangeDirectionWhenRoaming;

    protected virtual void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        hpForEmeny = GetComponent<HpForEmeny>();
        moveToTarget = GetComponent<MoveToTarget>();
        rb = GetComponent<Rigidbody2D>();

        roamState = new EnemyRoamState();
        chasingPlayerState = new EnemyChasingPlayerState();
        aTKState = new EnemyATKPlayerState();
        deathState = new DeathEnemyState();

        isFacingLeft = false;
        myDeathVFX = Instantiate(deathVFXGameObject, transform.position, Quaternion.identity);
        myDeathVFX.SetActive(false);
    }

    protected virtual void Start()
    {
        stateCurrent = roamState;
        stateCurrent.EnterState(this);
    }

    protected virtual void Update()
    {
        FlipSprite();
    }

    protected virtual void FixedUpdate()
    {
        if (stateCurrent != null)
        {
            stateCurrent.UpdateState(this);
        }
    }

    public void SetAnimationTrigger(string content)
    {
        animator.SetTrigger(content);
    }

    // Roam State
    public void ChooseRandomMove()
    {
        moveToTarget.ChooseRandomMove();
    }

    // Take DMG State
    public virtual void HandlerTakeDMG()
    {

    }

    public void TakeDMGEvent()
    {
        if (stateCurrent is EnemyATKPlayerState)
        {
            stateCurrent.ExitState(this);
        }
    }

    // Death State
    public virtual void DeathEvent()
    {
        gameObject.SetActive(false);
        myDeathVFX.SetActive(false);
    }

    // Chasing State
    public void ChangeStateToChasingPlayer()
    {
        if (stateCurrent != null)
        {
            stateCurrent.ExitState(this);
        }

        stateCurrent = chasingPlayerState;
        stateCurrent.EnterState(this);
    }

    public void ChangeSpeedWhenChasing()
    {
        moveToTarget.ChangeSpeed(speedWhenChasing);
    }


    // Death State
    public void DeathVFXEvent()
    {
        myDeathVFX.transform.position = transform.position;
        myDeathVFX.SetActive(true);
    }

    public void Death()
    {
        stateCurrent = deathState;
        stateCurrent.EnterState(this);
    }

    // Void About Change Speed

    public void ChangeSpeedToZero()
    {
        moveToTarget.ChangeSpeedToZero();
    }

    public void ChangeSpeedToHalf()
    {
        moveToTarget.ChangeSpeed(moveToTarget.Speed / 2);
    }

    public void BackToOriginSpeed()
    {
        moveToTarget.BackToOriginSpeed();
    }

    // Movement
    public void ChoosePlayerDirection()
    {
        moveToTarget.ChooseTargetDirecion(PlayerController.Instance.gameObject.transform.position);
    }

    // Sprite
    public Vector2 GetMoveDirection()
    {
        return moveToTarget.GetMoveDirection();
    }

    public void FlipSprite()
    {
        if (stateCurrent is EnemyRoamState)
        {
            if (moveToTarget.GetMoveDirection().x < 0)
            {
                if (!isFacingLeft)
                {
                    spriteRenderer.flipX = true;
                    isFacingLeft = true;
                }
            }
            else
            {
                if (isFacingLeft)
                {
                    spriteRenderer.flipX = false;
                    isFacingLeft = false;
                }
            }
            return;
        }
        else
        {
            if (moveToTarget.GetMoveDirection().x < transform.position.x)
            {
                if (!isFacingLeft)
                {
                    spriteRenderer.flipX = true;
                    isFacingLeft = true;
                }
            }
            else
            {
                if (isFacingLeft)
                {
                    spriteRenderer.flipX = false;
                    isFacingLeft = false;
                }
            }
        }
    }
}
