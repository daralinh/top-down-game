using UnityEngine;

public abstract class AAnimal : MonoBehaviour
{
    [Header("---- Components -----")]
    [SerializeField] protected HpForAnimal hpForAnimal;
    [SerializeField] protected Animator animator;
    [SerializeField] protected GameObject deathVFXPrefab;
    public bool IsDefensing {  get; protected set; }
    protected GameObject deathVFX;

    protected void Awake()
    {
        IsDefensing = false;
        deathVFX = Instantiate(deathVFXPrefab, transform.position, Quaternion.identity);
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
        Debug.Log("deathVFX");
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
