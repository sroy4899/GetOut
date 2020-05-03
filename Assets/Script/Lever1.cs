using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever1 : MonoBehaviour
{
    public GameObject handle;
    private float waitTime = 1.0f;
    private float timer = 0.0f;
    public static bool rotating = false;
    private Vector3 center = new Vector3(-8, 3, 49.5f);

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rotating)
        {
            timer += Time.deltaTime;
        }

        if(timer > waitTime)
        {
            transform.RotateAround(center, Vector3.right, 90);
            handle.transform.RotateAround(center, Vector3.right, 90);
            timer = 0.0f;
            rotating = false;
        }
    }

    private void OnMouseDown()
    {
        if (!Room3.finished && MazeBall.inMaze && !rotating && !Lever2.rotating2)
        {
            transform.RotateAround(center, Vector3.right, -90);
            handle.transform.RotateAround(center, Vector3.right, -90);
            Room3.lever1Pull = true;
            rotating = true;
        }
        
    }
}
