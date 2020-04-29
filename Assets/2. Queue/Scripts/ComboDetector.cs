using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BigMonster.EventManager;

public class ComboDetector : MonoBehaviour
{
    // Public
    public float tolerance = 0.5f;
    public int bufferSize = 4;
    public string debug;

    // Private
    private float counter;
    private Queue<KeyValuePair<float, string>> buffer;
    private string[] combo1 = new string[] { "down", "right", "P" };
    private string[] combo2 = new string[] { "right","down", "right", "P" };

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
        if(buffer.Count > 0)
            Verify();

        //Dequeue

        if (buffer.Count > bufferSize)
            buffer.Dequeue();
    }

    private void Verify()
    {
        bool comboflag1 = buffer.Count >= combo1.Length;
        bool comboflag2 = buffer.Count >= combo2.Length;

        for (int i = 0; i< buffer.Count;++i)
        {
            KeyValuePair<float, string> v = buffer.Dequeue();

            // check ////////////
            if (i < combo1.Length)
                comboflag1 = comboflag1 && (v.Value == combo1[i]);

            if (i < combo2.Length)
                comboflag2 = comboflag2 && (v.Value == combo2[i]);
            /////////////////////

            buffer.Enqueue(v);
        }
        if (comboflag1)
        {
            EventManager.TriggerEvent("SPECIAL", (object)"hadouken", this.gameObject);
            ResetCombo();
        }
        if (comboflag2)
        {
            EventManager.TriggerEvent("SPECIAL", (object)"dragon", this.gameObject);
            ResetCombo();
        }
    }

    private void DetectInput()
    {
        // ToDo: Enqueu de las demás teclas
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            buffer.Enqueue(new KeyValuePair<float, string>(Time.time, "up"));
            debug += "up, ";
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            buffer.Enqueue(new KeyValuePair<float, string>(Time.time, "down"));
            debug += "down, ";
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            buffer.Enqueue(new KeyValuePair<float, string>(Time.time, "left"));
            debug += "left, ";
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            buffer.Enqueue(new KeyValuePair<float, string>(Time.time, "right"));
            debug += "right, ";
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            buffer.Enqueue(new KeyValuePair<float, string>(Time.time, "K"));
            debug += "K, ";
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            buffer.Enqueue(new KeyValuePair<float, string>(Time.time, "P"));
            debug += "P, ";
        }
    }

    private void ResetCombo()
    {
        buffer = new Queue<KeyValuePair<float, string>>();
        debug = string.Empty;
        counter = -1;
    }
}
