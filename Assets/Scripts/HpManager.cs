using UnityEngine;

public class HpManager : MonoBehaviour
{
    [SerializeField] private float originHp;
    [SerializeField] private Animator animator;

    private float hp;
    private float oldCurrentHP;

    private void Update()
    {
        if (hp == 0)
        {
            animator.SetTrigger("Death");
        }
    }

    public float HP
    {
        get { return hp; }
        set { hp = Mathf.Max(0, value); }
    }

    public float OriginHp
    {
        get { return originHp; }
        set { originHp = Mathf.Max(1, value); }
    }

    private void Awake()
    {
        hp = originHp;
        oldCurrentHP = hp;
    }

    public void TakeDamge(float takedmg)
    {
        animator.SetBool("Alive", false);

        hp = Mathf.Max(hp - takedmg, 0);

        if (hp > 0)
        {
            animator.SetTrigger("TakeDMG");
        }
        else
        {
            animator.SetTrigger("Death");
        }
    }

    public void BuffHp(float hpBuff)
    {
        if (hpBuff < 0)
        {
            return;
        }

        if (hp < 0)
        {
            animator.SetTrigger("Death");
        }

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

    public void BuffOriginHp(float hpBuff)
    {
        originHp = Mathf.Max(originHp, originHp + hpBuff);
    }
}
