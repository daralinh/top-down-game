using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class AreaEnemy : MonoBehaviour
{
    private List<AEnemy> listEnemy;
    private BoxCollider2D boxCollider2D;

    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        listEnemy = new List<AEnemy>();
    }

    private void Start()
    {
        listEnemy = GetComponentsInChildren<AEnemy>().ToList();
        Debug.Log(listEnemy.Count);
    }
}
