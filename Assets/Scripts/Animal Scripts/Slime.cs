using System.Collections;
using UnityEngine;

public class Slime : AAnimal
{
    [SerializeField] private MoveToTarget moveToTarget;

    [Header("---- Parameters For Buff Speed ----")]
    [SerializeField] private float timeToBuffSpeed;
    [SerializeField] private float speedToBuff;

    private float originSpeed;
    private Coroutine coroutine = null;

    private void Start()
    {
        originSpeed = moveToTarget.Speed;
    }

    public override void DefenseHandler()
    {
        animator.SetTrigger("TakeDMG");
    }

    private IEnumerator Defense()
    {
        animator.SetBool("Run", true);
        yield return new WaitForSeconds(timeToBuffSpeed);

        IsDefensing = false;
        moveToTarget.ChangeSpeed(originSpeed);

        if (hpForAnimal.HP > 0)
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetTrigger("Death");
        }
    }

    public void TakeDMGEvent()
    {
        base.DefenseHandler();

        moveToTarget.ChangeSpeed(moveToTarget.Speed + speedToBuff);

        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }

        coroutine = StartCoroutine(Defense());

    }

    protected override void ResetDefense()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
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

        IsDefensing = false;
        gameObject.SetActive(false);
    }
}
