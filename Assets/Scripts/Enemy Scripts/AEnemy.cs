using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveToTarget))]
[RequireComponent(typeof(HpForEmeny))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]

public abstract class AEnemy : MonoBehaviour
{
    [SerializeField] protected float atkRange;
    [Header("Set origin speed in Component MoveToTarget")]
    [SerializeField] protected float speedWhenChasing;
    [SerializeField] protected float timeToChangeDirectionWhenRoaming;
    [SerializeField] protected GameObject deathVFXGameObject;
    protected EnemyArea enemyArea;

    protected IStateEnemy stateCurrent;
    protected IStateEnemy roamState;
    protected IStateEnemy chasingPlayerState;
    protected IStateEnemy aTKState;
    protected IStateEnemy deathState;
    protected IStateEnemy idleState;

    protected SpriteRenderer spriteRenderer;
    protected HpForEmeny hpForEmeny;
    protected Animator animator;
    protected MoveToTarget moveToTarget;
    protected Rigidbody2D rb;

    protected bool isFacingLeft;
    protected GameObject myDeathVFX;
    protected List<Node> pathToPlayer;

    public bool IsPlayerNearby { get; private set; }
    public float TimeToChangeDirectionWhenRoaming => timeToChangeDirectionWhenRoaming;

    protected virtual void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        hpForEmeny = GetComponent<HpForEmeny>();
        moveToTarget = GetComponent<MoveToTarget>();
        rb = GetComponent<Rigidbody2D>();
        enemyArea = GetComponentInParent<EnemyArea>();

        roamState = new EnemyRoamState();
        chasingPlayerState = new EnemyChasingPlayerState();
        aTKState = new EnemyATKPlayerState();
        deathState = new DeathEnemyState();
        idleState = new EnemyIdleState();

        rb.freezeRotation = true;
        isFacingLeft = false;
        myDeathVFX = Instantiate(deathVFXGameObject, transform.position, Quaternion.identity);
        myDeathVFX.SetActive(false);
        pathToPlayer = null;
    }

    protected virtual void Start()
    {
        stateCurrent = roamState;
        stateCurrent.EnterState(this);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    protected virtual void Update()
    {
        stateCurrent.UpdateState(this);
        FlipSprite();
    }

    protected virtual void FixedUpdate()
    {
        stateCurrent.FixedUpdateState(this);
    }

    public void SetAnimationTrigger(string content)
    {
        animator.SetTrigger(content);
    }

    // Idle State
    public void ChangeStateToIdle()
    {
        stateCurrent.ExitState(this);
        stateCurrent = idleState;
        stateCurrent.EnterState(this);
    }

    // Roam State
    public void ChangeStateToRoam()
    {
        stateCurrent.ExitState(this);
        stateCurrent = roamState;
        stateCurrent.EnterState(this);
    }

    public void ChooseRandomMove()
    {
        moveToTarget.ChooseRandomMove();
    }

    // Take DMG State
    public virtual void HandlerTakeDMG()
    {
    }

    public virtual void TakeDMGEvent()
    {
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

    public bool FindPathToPlayer()
    {
        pathToPlayer = enemyArea.PathToPlayer(gameObject);
        return pathToPlayer != null;
    }

    public void MoveFollowNodeInPathToPlayer()
    {
        if (pathToPlayer == null || pathToPlayer.Count == 0)
        {
            return;
        }

        Node targetNode = pathToPlayer[0];
        moveToTarget.ChooseTargetDirecion(((Vector2)targetNode.transform.position - rb.position).normalized);

        if (Vector2.Distance(rb.position, targetNode.transform.position) <= 0.1f)
        {
            pathToPlayer.RemoveAt(0);
        }
    }

    // Death State
    public void DeathVFXEvent()
    {
        myDeathVFX.transform.position = transform.position;
        myDeathVFX.SetActive(true);
    }

    public virtual void DeathEvent()
    {
        gameObject.SetActive(false);
        myDeathVFX.SetActive(false);
    }

    public void Death()
    {
        stateCurrent.ExitState(this);
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
