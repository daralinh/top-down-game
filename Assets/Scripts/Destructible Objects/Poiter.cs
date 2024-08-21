using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poiter : ADestructibleObject
{
    [Header("---- Components ----")]
    [SerializeField] private Animator animator;
    public override void TakeDMGHandler()
    {
        Death();
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
