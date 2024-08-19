using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armadillo : AAnimal
{
    [SerializeField] private int buffHpWhenTakeDMG;
    [SerializeField] private MoveToTarget moveToTarget;
    [SerializeField] private float timeToDefense;

    private float originSpeed;

    public override void DefenseHandler()
    {
        base.DefenseHandler();

        moveToTarget.ChangeSpeedToZero();
        hpForAnimal.BuffHp(buffHpWhenTakeDMG);
        StartCoroutine(Defense());
    }

    IEnumerator Defense()
    {
        yield return new WaitForSeconds(timeToDefense);

        moveToTarget.BackToOriginSpeed();
        hpForAnimal.BackToOldCurrentHP();

        if (hpForAnimal.HP > 0)
        {
            animator.SetBool("Run", true);
            yield return null;
        }
        else
        {
            animator.SetTrigger("Death");
        }
    }

    protected override void ResetDefense()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        
        IsDefensing = true;
        coroutine = StartCoroutine(Defense());
    }

    public override void Death()
    {
        StopAllCoroutines();
        base.Death();
    }
}
