using System.Collections;
using UnityEngine;

public class Slime : AAnimal
{
    [SerializeField] private MoveToTarget moveToTarget;
    [SerializeField] private float timeToBuffSpeed;
    [SerializeField] private float speedToBuff;

    private float originSpeed;

    private void Start()
    {
        originSpeed = moveToTarget.Speed;
    }

    public override void DefenseHandler()
    {
        base.DefenseHandler();

        moveToTarget.ChangeSpeed(moveToTarget.Speed + speedToBuff);
        animator.SetBool("Run", true);
        StartCoroutine(Defense());
    }

    private IEnumerator Defense()
    {
        yield return new WaitForSeconds(timeToBuffSpeed);

        IsDefensing = false;
        moveToTarget.ChangeSpeed(originSpeed);

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
        IsDefensing = true;

    }

    public override void Death()
    {
        StopAllCoroutines();
        base.Death();
    }
}
