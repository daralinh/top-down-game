using UnityEngine;

public abstract class AWeapon : MonoBehaviour
{
    [SerializeField]protected float dmg;
    [SerializeField]protected Animator animator;
    [SerializeField]protected SlashEffect slashEffect;
    [SerializeField]protected HitboxWeapon hitboxWeapon;

    protected PlayerControls playerControls;
    protected PlayerController playerController;
    protected ActiveWeapon activeWeapon;

    public float Damage
    {
        get { return dmg; }
        set { dmg = value; }
    }

    protected virtual void Awake()
    {
        playerController = GetComponentInParent<PlayerController>();
        playerControls = new PlayerControls();
        activeWeapon = GetComponentInParent<ActiveWeapon>();
        hitboxWeapon.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    protected virtual void Start()
    {
        if (animator == null)
        {
            Debug.Log("null animator");
        }

        playerControls.Combat.Attack.started += _ => Attacking();
    }

    protected virtual void Update()
    {
        MouseFollowWithOffset();
    }

    public void HideHitbox()
    {
        hitboxWeapon.gameObject.SetActive(false);
    }

    protected virtual void Attacking()
    {
        animator.SetTrigger("Attack");
    }

    public virtual void BuffDmg(float plus)
    {
        dmg += plus;
    }

    private void MouseFollowWithOffset()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(playerController.transform.position);

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        if (mousePos.x < playerScreenPoint.x)
        {
            activeWeapon.transform.rotation = Quaternion.Euler(0, -180, angle);
        }
        else
        {
            activeWeapon.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    public void SlashSwingUp()
    {
        slashEffect.gameObject.transform.rotation = Quaternion.Euler(-180, 0 ,0);
        slashEffect.gameObject.SetActive(true);
        hitboxWeapon.gameObject.SetActive(true);

        if (playerController.FacingLeft)
        {
            slashEffect.GetComponent<SpriteRenderer>().flipX = true;
        }
        else 
        {
            slashEffect.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    public void SlashSwingDown()
    {
        slashEffect.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        slashEffect.gameObject.SetActive(true);
        hitboxWeapon.gameObject.SetActive(true);

        if (playerController.FacingLeft)
        {
            slashEffect.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            slashEffect.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
