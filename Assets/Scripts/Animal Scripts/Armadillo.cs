using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armadillo : AAnimal
{
    [SerializeField] private MoveToTarget moveToTarget;
    [SerializeField] private KnockBack knockBack;

    [Header("---- Parameters for Defense ----")]
    [SerializeField] private float timeToDefense;
    [SerializeField] private int buffHpWhenTakeDMG;

    private Coroutine coroutine = null;

    public override void DefenseHandler()
    {
        base.DefenseHandler();

        animator.SetTrigger("Defense");
        moveToTarget.ChangeSpeedToZero();

        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }

        coroutine = StartCoroutine(Defense());
    }

    IEnumerator Defense()
    {
        yield return new WaitForSeconds(timeToDefense);

        moveToTarget.BackToOriginSpeed();
        hpForAnimal.BackToOldCurrentHP();
        IsDefensing = false;

        if (hpForAnimal.HP > 0)
        {
            animator.SetBool("Run", true);
        }
        else
        {
            Death();
        }
    }

    protected override void ResetDefense()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        
        coroutine = StartCoroutine(Defense());
    }

    public void DefenseEvent()
    {
        hpForAnimal.BuffHp(buffHpWhenTakeDMG);
    }

    public override void DeathEvent()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }

        IsDefensing = false;
        gameObject.SetActive(false);
    }
}
