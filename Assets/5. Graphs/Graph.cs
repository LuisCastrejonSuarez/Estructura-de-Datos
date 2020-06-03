using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public int pointer;
    public GraphNode[] Nodes;
    public int[,] Relations;
    public Graph (int size)
    {
        Nodes = new GraphNode[size];
        Relations = new int[size, size];

    }
    public void InitRelations()
    {
        if (Nodes.Length > 0)
        {
            Relations = new int[Nodes.Length, Nodes.Length];
            pointer = 0;
        }
    }
    public GraphNode Current()
    {
        return Nodes[pointer];
    }
    public List<GraphNode> CurrentConections()
    {
        List<GraphNode> tmp= new List<GraphNode>();
        for (int i = 0; i < Nodes.Length; ++i)
        {
            if (Relations[pointer, i] == 1)
                tmp.Add(Nodes[i]);
        }
        return tmp;
    }
}
