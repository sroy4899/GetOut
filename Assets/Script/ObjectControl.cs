﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectControl : MonoBehaviour
{
    private bool holding;
    public Camera c;
    public GameObject frame;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        holding = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (holding)
        {
            transform.position = c.transform.position + c.transform.forward;
            transform.forward = c.transform.forward * -1;

            if (Input.GetKeyDown(KeyCode.R))
            {
                if (Vector3.Distance(transform.position, frame.transform.position) < 2)
                {
                    transform.position = frame.transform.position;
                    rb.constraints = RigidbodyConstraints.FreezePosition;

                    holding = false;
                }
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                holding = false;
                rb.constraints = RigidbodyConstraints.None;
                rb.constraints = RigidbodyConstraints.FreezeRotation;
            }
        }
    }

    void OnMouseDown()
    {
        holding = true;
    }
}
