using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public List<int> doors;
    public Color color;
    public Room()
    {
        doors = new List<int>();
    }
    public Room(int[] list, Color c)
    {
        doors = new List<int>();
        for(int i=0;i<list.Length; ++i)
        {
            doors.Add(list[i]);
        }

        color = c;
    }
}
