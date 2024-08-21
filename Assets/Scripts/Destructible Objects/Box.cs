using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : ADestructibleObject
{
    [Header("---- Components ----")]
    [SerializeField] private Animator animator;

    public override void TakeDMGHandler()
    {
        animator.SetBool("Idle", false);
        animator.SetTrigger("TakeDMG");
    }

    public override void TakeDMGEvent()
    {
        animator.SetBool("Idle", true);
    }

    public override void Death()
    {
        animator.SetTrigger("Death");
    }

    public override void DeathEvent()
    {
        base.DeathEvent();
    }
}
