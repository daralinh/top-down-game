using UnityEngine;

public abstract class AHpManager : MonoBehaviour
{
    [SerializeField] protected float originHp;
    [SerializeField] protected FlashSprite flashSprite;

    protected float hp;
    protected float oldCurrentHP;

    public float HP
    {
        get { return hp; }
        private set { hp = value; }
    }

    public float OriginHp
    {
        get { return originHp; }
        private set { originHp = value; }
    }

    protected virtual void Awake()
    {
        Born();
    }

    public abstract void TakeDMG(Transform source, float takedDMG, bool CanKnockBack);

    public virtual void Born()
    {
        hp = originHp;
        oldCurrentHP = hp;
    }

    public void BuffHp(float hpBuff)
    {
        oldCurrentHP = hp;
        hp += hpBuff;
    }

    public void BackToOriginHP()
    {
        hp = originHp;
    }

    public void BackToOldCurrentHP()
    {
        hp = Mathf.Min(hp, oldCurrentHP);
        oldCurrentHP = hp;
    }

    public void SetCurrentHp(float newCurrentHp)
    {
        hp = newCurrentHp;
        oldCurrentHP = hp;
    }

    public void ChangeOriginHp(float newOriginHp)
    {
        originHp = Mathf.Max(1, newOriginHp);
    }
}
