using UnityEngine;

public class HpForMineral : AHpManager
{
    private AMinerals aMinerals;
    public bool SetSmall { get; private set; }

    protected override void Awake()
    {
        aMinerals = GetComponent<AMinerals>();
        base.Awake();
    }

    public override void TakeDMG(Transform source, float takedDMG, bool canKnockBack)
    {
        canKnockBack = false;

        hp = Mathf.Max(hp - takedDMG, 0);

        if (hp == 0)
        {
            aMinerals.SetSmall();
        }
    }
}
