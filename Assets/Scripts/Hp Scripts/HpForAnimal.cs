using UnityEngine;

public class HpForAnimal : AHpManager
{
    [SerializeField] protected Animator animator;

    public bool IsDefensing { get; private set; }

    public override void TakeDMG(float takedDMG)
    {
        Debug.Log($"{hp} - {takedDMG} = {hp - takedDMG}");

        flashSprite.Flash();

        animator.SetBool("Run", false);

        hp = Mathf.Max(hp - takedDMG, 0);


        if (hp > 0)
        {
            IsDefensing = true;
            animator.SetTrigger("Defense");
        }
        else
        {
            IsDefensing = false;
            animator.SetTrigger("Death");
        }
    }
}
