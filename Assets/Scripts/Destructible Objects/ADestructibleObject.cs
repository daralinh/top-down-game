using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADestructibleObject: MonoBehaviour
{
    public virtual void TakeDMGHandler()
    {

    }

    public virtual void TakeDMGEvent()
    {

    }

    public virtual void Death()
    {

    }

    public virtual void DeathEvent()
    {
        gameObject.SetActive(false);
    }
}
