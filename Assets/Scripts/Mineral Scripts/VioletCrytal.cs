using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VioletCrytal : AMinerals
{
    protected override void AddListValue()
    {
        listValue = new float[] { 30, 25, 15, 5 };
    }
}
