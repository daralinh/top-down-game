using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitTree : ATree
{
    // Start is called before the first frame update
    protected override void GetOriginValue()
    {
        originValue = Random.Range(10, 15);
    }
}
