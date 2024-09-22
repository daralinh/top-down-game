using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(AStar))]

public class EnemyArea : MonoBehaviour
{
    private List<AEnemy> listEnemy = new List<AEnemy>();
    private BoxCollider2D boxCollider2D;

    private AStar aStar;

    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        boxCollider2D.isTrigger = true;
        aStar = GetComponentInParent<AStar>();
    }

    private void Start()
    {
        listEnemy = GetComponentsInChildren<AEnemy>().ToList();

        Debug.Log("Enemy: " + listEnemy.Count);
        int count = 0;
        foreach (var enemy in listEnemy)
        {
            Debug.Log((++count).ToString() + enemy.name); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerEnter();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerExit();
        }
    }

    private void PlayerEnter()
    {
        foreach(AEnemy enemy in listEnemy)
        {
            Debug.Log($"{enemy.name} => chasing");
            enemy.ChangeStateToChasingPlayer();
        }
    }

    private void PlayerExit()
    {
        foreach (AEnemy enemy in listEnemy)
        {
            Debug.Log($"{enemy.name} => idle");
            enemy.ChangeStateToIdle();
        }
    }

    public List<Node> PathToPlayer(GameObject gameObject)
    {
        if (aStar.IsWorking)
        {
            return null;
        }

        return aStar.FindPath(gameObject, PlayerController.Instance.gameObject);
    }
}
