using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : AMinerals
{
    protected override void AddListValue()
    {
        listValue = new int[] {25, 20, 15, 5};
    }
}
