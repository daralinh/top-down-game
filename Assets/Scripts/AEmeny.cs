using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AEmeny : MonoBehaviour
{
    [SerializeField] protected HpManager hpManager;
    [SerializeField] protected Animator animator;
    [SerializeField] protected CapsuleCollider2D capsuleCollider2D;

    public virtual void HandlerTakeDMG()
    {
        animator.SetBool("Alive", true);
    }

    public virtual void HandlerDeath()
    {
        gameObject.SetActive(false);
    }
}
