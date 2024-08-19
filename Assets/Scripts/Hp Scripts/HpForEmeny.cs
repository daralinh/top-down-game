using UnityEngine;

public class HpForEmeny : AHpManager
{
    [SerializeField] protected Animator animator;

    public override void TakeDMG(float takedDMG)
    {
        flashSprite.Flash();

        animator.SetBool("Run", false);

        hp = Mathf.Max(hp - takedDMG, 0);

        if (hp > 0)
        {
            animator.SetTrigger("TakeDMG");
        }
        else
        {
            animator.SetTrigger("Death");
        }
    }
}
