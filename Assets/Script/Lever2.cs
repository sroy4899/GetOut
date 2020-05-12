using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever2 : MonoBehaviour
{
    public GameObject handle;
    public AudioClip rotate; 
    private AudioSource audioSource;
    private float waitTime = 1.0f;
    private float timer = 0.0f;
    public static bool rotating2 = false;
    private Vector3 center = new Vector3(-6, 3, 49.5f);

    void Start() { 
        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (rotating2)
        {
            timer += Time.deltaTime;
        }

        if(timer > waitTime)
        {
            transform.RotateAround(center, Vector3.right, 90);
            handle.transform.RotateAround(center, Vector3.right, 90);
            timer = 0.0f;
            rotating2 = false;
        }
    }

    private void OnMouseDown()
    {
        if (!Room3.finished && MazeBall.inMaze && !rotating2 && !Lever1.rotating)
        {
            audioSource.PlayOneShot(rotate);
            transform.RotateAround(center, Vector3.right, -90);
            handle.transform.RotateAround(center, Vector3.right, -90);
            Room3.lever2Pull = true;
            rotating2 = true;
        }
        
    }
}
