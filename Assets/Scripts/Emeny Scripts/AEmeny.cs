using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AEmeny : MonoBehaviour
{
    [SerializeField] protected HpForEmeny hpForEmeny;
    [SerializeField] protected Animator animator;
    [SerializeField] protected CapsuleCollider2D capsuleCollider2D;

    public virtual void HandlerTakeDMG()
    {
        animator.SetBool("Alive", true);
    }

    public virtual void DeathEvent()
    {
        gameObject.SetActive(false);
    }

    public void Death()
    {
        animator.SetTrigger("Death");
    }
}
