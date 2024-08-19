using UnityEngine;

public class HpForEmeny : AHpManager
{
    [SerializeField] protected Animator animator;
    [SerializeField] protected KnockBack knockBack;
    [SerializeField] protected AEmeny emeny;

    public override void TakeDMG(Transform source, float takedDMG, bool canKnockBack)
    {
        flashSprite.Flash();

        hp = Mathf.Max(hp - takedDMG, 0);

        if (canKnockBack)
        {
            knockBack.GetKnockBack(source);
        }

        if (hp > 0)
        {
            emeny.HandlerTakeDMG();
        }
        else
        {
            emeny.Death();
        }
    }
}
