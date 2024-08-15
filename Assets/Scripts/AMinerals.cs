using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public abstract class AMinerals : MonoBehaviour
{
    [SerializeField] protected Sprite[] listSprite;
    protected int[] listValue;
    protected int index;
    protected int maxIndex;

    protected SpriteRenderer spriteRenderer;

    protected float valueStatus;
    protected bool alive;

    protected virtual void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        AddListValue();
        maxIndex = listSprite.Length - 1;
        index = 0;
        ChangeSprite(0);
        alive = true;
    }

    public int TotalValueNow()
    {
        int sum = 0;
        foreach(int i in listValue)
        {
            sum += i;
        }
        return sum;
    }

    public void GetSmall()
    {
        if (index == maxIndex)
        {
            Death();
            return;
        }

        ChangeSprite(++index);
    }

    public void GetBig()
    {
        index = math.max(--index, 0);
        ChangeSprite(index);
    }

    public void Reborn()
    {
        alive = true;
        index = 0;
        valueStatus = listValue[index];
        ChangeSprite(0);
        gameObject.SetActive(true);
    }

    public void Death()
    {
        alive = false;
        valueStatus = 0;
        gameObject.SetActive(false);
    }

    private void ChangeSprite(int indexSprite)
    {
        spriteRenderer.sprite = listSprite[indexSprite];
        valueStatus = listValue[indexSprite];
    }

    protected abstract void AddListValue();
}