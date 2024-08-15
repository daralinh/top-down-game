using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxWeapon : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Emeny")
        {
            Debug.Log($"attack  {collision.tag}");
        }
    }

    public void HideHitboxWeapon()
    {
        gameObject.SetActive(false);
    }
}
