using UnityEngine;

public class HpForAnimal : AHpManager
{
    [Header("---- Components ----")]
    [SerializeField] private Animator animator;
    [SerializeField] private KnockBack knockBack;
    private AAnimal animal;

    protected override void Awake()
    {
        animal = GetComponent<AAnimal>();
        base.Awake();
    }

    public override void TakeDMG(Transform source, float takedDMG, bool canKnockBack)
    {
        flashSprite.Flash();

        animator.SetBool("Run", false);

        hp = Mathf.Max(hp - takedDMG, 0);

        Debug.Log($"{hp}");

        if (canKnockBack)
        {
            knockBack.GetKnockBack(source);
        }

        if (hp > 0)
        {
            animal.DefenseHandler();
        }
        else
        {
            animal.Death();
        }
    }
}
