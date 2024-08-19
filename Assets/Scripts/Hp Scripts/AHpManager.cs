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
        private set { hp = Mathf.Max(0, value); }
    }

    public float OriginHp
    {
        get { return originHp; }
        private set { originHp = Mathf.Max(1, value); }
    }

    protected virtual void Awake()
    {
        Born();
    }

    public abstract void TakeDMG(float takedDMG);

    public virtual void Born()
    {
        hp = originHp;
        oldCurrentHP = hp;
    }

    public virtual void BuffHp(float hpBuff)
    {
        oldCurrentHP = hp;
        hp += hpBuff;
    }

    public virtual void BackToOriginHP()
    {
        hp = originHp;
    }

    public virtual void BackToOldCurrentHP()
    {
        hp = Mathf.Min(hp, oldCurrentHP);
        oldCurrentHP = hp;
    }

    public virtual void SetCurrentHp(float newCurrentHp)
    {
        hp = newCurrentHp;
        oldCurrentHP = hp;
    }

    public virtual void ChangeOriginHp(float newOriginHp)
    {
        originHp = Mathf.Max(1, newOriginHp);
    }

}
