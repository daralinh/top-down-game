using UnityEngine;

[RequireComponent (typeof(FlashSprite))]
public abstract class AHpManager : MonoBehaviour
{
    protected FlashSprite flashSprite;
    [SerializeField] protected float originHp;

    protected float hp;
    protected float oldCurrentHP;

    public float HP
    {
        get => hp;
        private set => hp = value;
    }

    public float OriginHp
    {
        get => originHp;
        private set => originHp = value;
    }

    protected virtual void Awake()
    {
        flashSprite = GetComponent<FlashSprite>();
        Born();
    }

    public abstract void TakeDMG(Transform source, float takedDMG, bool canKnockBack);

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
