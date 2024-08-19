using UnityEngine;

public abstract class AAnimal : MonoBehaviour
{
    [SerializeField] protected HpForAnimal hpForAnimal;
    [SerializeField] protected Animator animator;

    public bool IsDefensing {  get; protected set; }

    protected void Awake()
    {
        IsDefensing = false;
    }

    public virtual void DefenseHandler()
    {
        if (IsDefensing)
        {
            ResetDefense();
            return;
        }

        IsDefensing = true;
    }

    protected abstract void ResetDefense();

    public virtual void DeathEvent()
    { 
        gameObject.SetActive(false);
    }

    public virtual void Death()
    {
        IsDefensing = false;
        animator.SetTrigger("Death");
    }
}
