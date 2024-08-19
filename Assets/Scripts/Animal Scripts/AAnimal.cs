using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AAnimal : MonoBehaviour
{
    [SerializeField] protected HpForAnimal hpForAnimal;
    [SerializeField] protected Animator animator;
    [SerializeField] protected CapsuleCollider2D capsuleCollider2D;

    protected Coroutine coroutine;
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

    public virtual void Death()
    {
        IsDefensing = false;
        gameObject.SetActive(false);
    }
}
