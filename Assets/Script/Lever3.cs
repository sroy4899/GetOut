using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever3 : MonoBehaviour
{
    public GameObject handle;
    private float waitTime = 0.5f;
    private float timer = 0.0f;
    private bool moving = false;
    private Vector3 center = new Vector3(7, 3, 49.5f);

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moving)
        {
            timer += Time.deltaTime;
        }

        if(timer > waitTime)
        {
            transform.RotateAround(center, Vector3.right, 90);
            handle.transform.RotateAround(center, Vector3.right, 90);
            timer = 0.0f;
            moving = false;
        }
    }

    private void OnMouseDown()
    {
        if (!Room3.finished && MazeBall.inMaze && !moving && !Lever1.rotating && !Lever2.rotating2)
        {
            transform.RotateAround(center, Vector3.right, -90);
            handle.transform.RotateAround(center, Vector3.right, -90);
            Room3.lever3Pull = true;
            moving = true;
        }
        
    }
}
