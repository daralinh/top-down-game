using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpForDestructibleObject : AHpManager
{
    [Header("---- Components ----")]
    [SerializeField] private ADestructibleObject destructibleObject;

    public override void TakeDMG(Transform source, float takedDMG, bool canKnockBack)
    {
        flashSprite.Flash();

        hp = Mathf.Max(hp - takedDMG, 0);

        if (hp > 0)
        {
            destructibleObject.TakeDMGHandler();
        }
        else
        {
            destructibleObject.Death();
        }

    }
}
