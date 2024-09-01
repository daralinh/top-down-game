using UnityEngine;

public abstract class AAnimal : MonoBehaviour
{
    [Header("---- Components -----")]
    [SerializeField] protected HpForAnimal hpForAnimal;
    [SerializeField] protected Animator animator;
    [SerializeField] protected GameObject deathVFXGameObject;
    public bool IsDefensing {  get; protected set; }
    protected GameObject deathVFX;

    protected void Awake()
    {
        IsDefensing = false;
        deathVFX = Instantiate(deathVFXGameObject, transform.position, Quaternion.identity);
        deathVFX.SetActive(false);
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

    public void DeathVFXEvent()
    {
        deathVFX.transform.position = transform.position;
        deathVFX.SetActive(true);
    }

    public virtual void DeathEvent()
    {
        deathVFX.SetActive(false);
        gameObject.SetActive(false);
    }

    public void Death()
    {
        animator.SetTrigger("Death");
    }
}
