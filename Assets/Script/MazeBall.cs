using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MazeBall : MonoBehaviour
{
    public static bool holding; 
    public Text dropText;
    public Camera c;
    private Rigidbody rb;
    public static bool inMaze = false;
    private Vector3 startPos = new Vector3(-2.8125f, 2.1875f, 49.75f);

    // Start is called before the first frame update
    void Start()
    {
        holding = false;
        rb = GetComponent<Rigidbody>();
        dropText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (holding)
        { 
            dropText.text = "Press F to drop item";
            transform.position = c.transform.position + c.transform.forward;
            transform.forward = c.transform.forward * -1;
            rb.Sleep();

            if (Input.GetKeyDown(KeyCode.F))
            {
                dropText.text = "";
                rb.WakeUp();
                holding = false;

                if (Vector3.Distance(transform.position, startPos) < 2 && transform.position.x > -3.125f && transform.position.x < 2.5f)
                {
                    inMaze = true;
                    gameObject.SetActive(false);
                }
            }
        }
    }

    void OnMouseDown()
    {
        if (!inMaze)
        {
            holding = true;
        }
    }
}
