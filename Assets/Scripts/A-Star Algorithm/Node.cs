using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private List<Node> neighbor = new List<Node>();

    public float GCost { get; private set; }
    public float HCost { get; private set; }
    public float FCost => GCost + HCost;

    public Node Father { get; private set; }
    public List<Node> Neighbor => neighbor;

    public void SetGCost(float _cost)
    {
        GCost = _cost;
    }
    public void SetHCost(float _hCost)
    {
        HCost = _hCost;
    }   
    public void SetFatherNode(Node _parentNode)
    {
        Father = _parentNode;
    }

    public void AddNeighborNode(Node _neighborNode)
    {
        if (Neighbor.Count > 8 || neighbor.Contains(_neighborNode))
        {
            return;
        }

        neighbor.Add(_neighborNode);
    }

    private void OnDrawGizmos()
    {
        foreach(var _node in neighbor)
        {
            Gizmos.DrawLine(transform.position, _node.transform.position);
        }
    }
}
