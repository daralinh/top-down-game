using UnityEngine;

public class HpForEmeny : AHpManager
{
    [Header("---- Components ----")]
    [SerializeField] private Animator animator;
    [SerializeField] private KnockBack knockBack;
    private AEmeny emeny;

    protected override void Awake()
    {
        emeny = GetComponent<AEmeny>();
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
