using UnityEngine;

public abstract class AMinerals : MonoBehaviour
{
    [SerializeField] protected HpForMineral hpForMineral;

    protected float[] listValue;
    protected int index;
    protected int maxIndex;
    public float CurrentValue {  get; protected set; }

    protected virtual void Awake()
    {
        AddListValue();
        maxIndex = listValue.Length-1;
    }

    public virtual void Born()
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