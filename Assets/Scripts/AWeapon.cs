using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class AWeapon : MonoBehaviour
{
    [SerializeField]protected float dmg;
    protected PlayerControls playerControls;
    protected PlayerController playerController;
    protected ActiveWeapon activeWeapon;
    protected Animator animator;

    public float DMG;

    protected virtual void Awake()
    {
        playerController = GetComponentInParent<PlayerController>();
        playerControls = new PlayerControls();
        activeWeapon = GetComponentInParent<ActiveWeapon>();
        animator = GetComponent<Animator>();
        DMG = dmg;
    }

    protected virtual void Start()
    {
        playerControls.Combat.Attack.started += _ => Attacking();
    }

    protected virtual void Update()
    {
        MouseFollowWithOffset();
    }

    public virtual void EnableOn()
    {
        gameObject.SetActive(true);
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
}
