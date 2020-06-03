using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphNode : MonoBehaviour
{
    object Data { set; get; }
    public  GraphNode(object obj)
    {
        Data = obj;
    }

}
