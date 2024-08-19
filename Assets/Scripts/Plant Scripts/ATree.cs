using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ATree : MonoBehaviour
{
    [SerializeField] protected Sprite[] spriteAlive;
    [SerializeField] protected Sprite[] spriteRoot;
    [SerializeField] protected Sprite[] spriteBurn;

    protected SpriteRenderer spriteRenderer;
    protected Sprite spriteAliveOrigin;
    protected Sprite spriteRootOrigin;
    protected Sprite spriteBurnOrigin;

    protected int originValue;
    protected int valueNow;
    protected bool alive;

    public int ValueNow;
    public bool Alive;

    protected virtual void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        ChooseOriginSprite();
        spriteRenderer.sprite = spriteAliveOrigin;

        GetOriginValue();
        valueNow = originValue;
        ValueNow = valueNow;

        alive = true;
        Alive = alive;
    }

    public void Born()
    {
        valueNow = originValue;
    }

    public void ReduceValue(int dmg)
    {
        valueNow -= dmg;
        valueNow = Mathf.Max(valueNow, 0);
    }

    protected void ChooseOriginSprite()
    {
        int randomIndex = Random.Range(0, spriteAlive.Length);
        spriteAliveOrigin = spriteAlive[randomIndex];

        randomIndex = Random.Range(0, spriteRoot.Length);
        spriteRootOrigin = spriteRoot[randomIndex];

        randomIndex = Random.Range(0, spriteBurn.Length);
        spriteBurnOrigin = spriteBurn[randomIndex];
    }

    protected abstract void GetOriginValue();
}
