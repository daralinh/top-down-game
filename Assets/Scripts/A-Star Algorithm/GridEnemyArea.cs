using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class GridEnemyArea : MonoBehaviour
{
    private List<Node> listnode = new List<Node>();

    public List<Node> ListNode => listnode; 

    private void Start()
    {
        InitializeNodes();
    }

    private void InitializeNodes()
    {
        listnode = GetComponentsInChildren<Node>().ToList();
        Debug.Log("Number of Node" + listnode.Count);
    }

    public void AddNode(Node newNode)
    {
        if (listnode.FirstOrDefault(x => x.transform.position == newNode.transform.position) == null)
        {
            listnode.Add(newNode);
        }
    }
}
