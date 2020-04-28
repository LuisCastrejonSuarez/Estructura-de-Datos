using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboDetector : MonoBehaviour
{
    // Public
    public float tolerance = 0.5f;
    public int bufferSize = 4;
    public string debug;

    // Private
    private float counter;
    private Queue<KeyValuePair<float, string>> buffer;
    private string[] combo1 = new string[] { "P", "right", "down" };
    private string[] combo2 = new string[] { "K", "right", "down" };

    void Awake()
    {
        buffer = new Queue<KeyValuePair<float, string>>();
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            counter = tolerance;
        }
        else if (counter != -1)
        {
            counter -= Time.deltaTime;
        }
        if(counter<0)
        {
            ResetCombo();
        }

        //Enqueue

        DetectInput();

        //Detection
        // ToDo: Verificar combo
        Verify();

        //Dequeue

        if (buffer.Count > bufferSize)
            buffer.Dequeue();
    }

    private void Verify()
    {
        buffer.Peek();
        buffer.Dequeue();
    }

    private void DetectInput()
    {
        // ToDo: Enqueu de las demás teclas
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            buffer.Enqueue(new KeyValuePair<float, string>(Time.time, "down"));
            debug += "down, ";
        }
    }

    private void ResetCombo()
    {
        buffer = new Queue<KeyValuePair<float, string>>();
        debug = string.Empty;
        counter = -1;
    }
}
