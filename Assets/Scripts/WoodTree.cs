using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodTree : ATree
{
    // Start is called before the first frame update
    protected override void GetOriginValue()
    {
        originValue = 50;
    }
}
