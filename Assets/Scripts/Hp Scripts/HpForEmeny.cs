using UnityEngine;

[RequireComponent (typeof(KnockBack))]
public class HpForEmeny : AHpManager
{
    private KnockBack knockBack;
    private AEnemy emeny;

    protected override void Awake()
    {
        knockBack = GetComponent<KnockBack>();
        emeny = GetComponent<AEnemy>();
        base.Awake();
    }

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
