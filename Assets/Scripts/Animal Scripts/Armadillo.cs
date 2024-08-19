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
        hpForAnimal.BuffHp(buffHpWhenTakeDMG);
        coroutine = StartCoroutine(Defense());
    }

    IEnumerator Defense()
    {
        Debug.Log($"+ coroutine {hpForAnimal.HP}");
        yield return new WaitForSeconds(timeToDefense);

        moveToTarget.BackToOriginSpeed();
        hpForAnimal.BackToOldCurrentHP();
        IsDefensing = false;

        if (hpForAnimal.HP > 0)
        {
            animator.SetBool("Run", true);
            yield return null;
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
            coroutine = null;
        }
        
        coroutine = StartCoroutine(Defense());
    }

    public override void DeathEvent()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }

        base.DeathEvent();
    }
}
