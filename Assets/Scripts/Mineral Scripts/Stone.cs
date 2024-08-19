using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : AMinerals
{
    protected override void AddListValue()
    {
        listValue = new float[] { 40, 35, 25, 15};
    }
}
