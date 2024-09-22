using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AStar : MonoBehaviour
{
    private List<Node> listNodes = new List<Node>();

    public bool IsWorking { get; private set; }

    private void Start()
    {
        GetAllNodes();
        IsWorking = false;
    }

    private void GetAllNodes()
    {
        listNodes = GetComponentsInChildren<Node>().ToList();
    }

    public List<Node> FindPath(GameObject _start, GameObject _end)
    {
        IsWorking = true;

        Debug.Log(_start.gameObject.name);
        Debug.Log(_end.gameObject.name);

        Node startPath = listNodes.OrderBy(a => Vector2.Distance(a.transform.position, _start.transform.position)).First();
        Node endPath = listNodes.OrderBy(a => Vector2.Distance(a.transform.position, _end.transform.position)).First();

        Debug.Log(startPath.gameObject.name);
        Debug.Log(endPath.gameObject.name);

        return GeneratePath(startPath, endPath);
    }

    private List<Node> GeneratePath(Node _start, Node _end)
    {
        List<Node> openSet = new List<Node>();

        foreach (Node node in listNodes)
        {
            node.SetGCost(float.MaxValue);
        }

        _start.SetGCost(0f);
        _start.SetHCost(Vector2.Distance(_start.gameObject.transform.position, _end.gameObject.transform.position));
        openSet.Add(_start);

        if (openSet.Count > 0)
        {
            Node currentNode = listNodes.First(a => a.FCost == listNodes.Min(b => b.FCost));
            openSet.Remove(currentNode);

            if (currentNode == _end)
            {
                List<Node> path = new List<Node>();
                path.Prepend(currentNode);

                while (currentNode != _start)
                {
                    currentNode = currentNode.Father;
                    path.Add(currentNode);
                }

                path.Reverse();
                IsWorking = false;
                Debug.Log("Path " + path.Count);
                foreach (Node node in path)
                {
                    Debug.Log(node.gameObject.name);
                }
                return path;
            }

            foreach (Node node in currentNode.Neighbor)
            {
                float heldGCost = currentNode.GCost + 
                                    Vector2.Distance(currentNode.transform.position, node.transform.position);
                if (heldGCost < node.GCost)
                {
                    node.SetFatherNode(currentNode);
                    node.SetGCost(heldGCost);
                    node.SetHCost(Vector2.Distance(node.transform.position, _end.transform.position));

                    if (!openSet.Contains(node))
                    {
                        openSet.Add(node);
                    }
                }
            }
        }

        IsWorking = false;
        return null;
    }
}
