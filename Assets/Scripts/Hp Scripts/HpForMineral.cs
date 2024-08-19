using UnityEngine;

public class HpForMineral : AHpManager
{
    [SerializeField] private AMinerals aMinerals;
    public bool SetSmall { get; private set; }

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
