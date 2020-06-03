using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphController : MonoBehaviour
{
    public Graph graph;
    void Start()
    {
        InitGraph();
        List<GraphNode> nodes = graph.CurrentConections();
        foreach (GraphNode node in nodes)
            Debug.Log("coneciones siguientes:"+node.gameObject.name);
    }

    private void InitGraph()
    {
        graph.InitRelations();
        graph.Relations[0, 2] = 1;

        graph.Relations[1, 3] = 1;
        graph.Relations[1, 4] = 1;

        graph.Relations[2, 0] = 1;
        graph.Relations[2, 4] = 1;

        graph.Relations[3, 1] = 1;
        graph.Relations[3, 4] = 1;

        graph.Relations[4, 1] = 1;
        graph.Relations[4, 2] = 1;
        graph.Relations[4, 3] = 1;
    }
}
