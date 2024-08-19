using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public abstract class AMinerals : MonoBehaviour
{
    [SerializeField] protected HpForMineral hpForMineral;

    protected float[] listValue;
    protected int index;
    protected int maxIndex;

    protected virtual void Awake()
    {
        AddListValue();
        index = 0;
        maxIndex = listValue.Length-1;
    }

    public void Born()
    {
        index = 0;
        hpForMineral.ChangeOriginHp(listValue[0]);
        hpForMineral.SetCurrentHp(listValue[0]);
        gameObject.SetActive(true);
    }

    public void SetSmall()
    {
        if (maxIndex < ++index)
        {
            gameObject.SetActive(false);
            return;
        }

        hpForMineral.ChangeOriginHp(listValue[index]);
        hpForMineral.SetCurrentHp(listValue[index]);
    }

    protected abstract void AddListValue();
}