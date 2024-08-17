using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armadillo : AAnimal
{
    [SerializeField] private int buffHpWhenTakeDMG;
    [SerializeField] private RoamingNoneTarget roamingNoneTarget;
    [SerializeField] private float timeToDefense;

    private float originSpeed;
    private bool isCoroutineRunning = false;

    public override void HandlerTakeDMG()
    {
        if (isCoroutineRunning)
        {
            StopCoroutine(Defense());
            StartCoroutine(Defense());
            return;
        }

        roamingNoneTarget.ChangeSpeedToZero();
        hpManager.BuffHp(buffHpWhenTakeDMG);
        StartCoroutine(Defense());
    }

    private IEnumerator Defense()
    {
        isCoroutineRunning = true;

        yield return new WaitForSeconds(timeToDefense);

        isCoroutineRunning = false;

        if (hpManager.HP > 0)
        {
            roamingNoneTarget.BackToOriginSpeed();
            hpManager.BackToOldCurrentHP();
            animator.SetBool("Alive", true);
            yield return null;
        }

        animator.SetTrigger("Death");
    }

    public override void HandlerDeath()
    {
        StopAllCoroutines();
        base.HandlerDeath();
    }
}
