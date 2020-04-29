﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BigMonster.EventManager;
public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// Inputs
    /// - Punches: Q,W,E
    /// - Kicks: A,S.D
    /// - Movement: Arrows
    /// </summary>

    // Private

    private ComboDetector detector;
    private Animator animator;

    void Awake()
    {
        detector = GetComponent<ComboDetector>();
        EventManager.StartListening("SPECIAL", Listener);
        animator = GetComponent<Animator>();
    }




    private void Listener(object data, GameObject sender)
    {
        string attack = (string)data;

        Debug.Log("sent: " + attack);
        animator.SetTrigger(attack);

    }


    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Q))
            Debug.Log("Q");
        if (Input.GetKeyDown(KeyCode.W))
            Debug.Log("W");
        if (Input.GetKeyDown(KeyCode.E))
            Debug.Log("E");
        if (Input.GetKeyDown(KeyCode.A))
            Debug.Log("A");
        if (Input.GetKeyDown(KeyCode.S))
            Debug.Log("S");
        if (Input.GetKeyDown(KeyCode.D))
            Debug.Log("D");
        if (Input.GetKeyDown(KeyCode.DownArrow))
            Debug.Log("Down");
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            Debug.Log("Left");
        if (Input.GetKeyDown(KeyCode.RightArrow))
            Debug.Log("Right");
        if (Input.GetKeyDown(KeyCode.UpArrow))
            Debug.Log("Up");
            */
    }
}
