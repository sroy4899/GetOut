using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardControl : MonoBehaviour
{
    private bool holding;
    public Camera c;
    private Rigidbody rb;
    private Main.Frame mine;

    // Start is called before the first frame update
    void Start()
    {
        holding = false;
        rb = GetComponent<Rigidbody>();
        mine = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (holding)
        {
            transform.position = c.transform.position + c.transform.forward;
            transform.forward = c.transform.forward * -1;
            rb.Sleep();

            if (Input.GetKeyDown(KeyCode.F))
            {
                rb.WakeUp();
                holding = false;

                Main.Frame closest = closestFrame();

                if (!closest.hasCard && (Vector3.Distance(transform.position, closest.obj.transform.position) < 2))
                {
                    closest.hasCard = true;
                    closest.cardVal = gameObject.name;
                    mine = closest;
                    transform.position = closest.obj.transform.position;
                    rb.constraints = RigidbodyConstraints.FreezePosition;
                }
                else
                {
                    rb.constraints = RigidbodyConstraints.None;
                    rb.constraints = RigidbodyConstraints.FreezeRotation;
                    //transform.rotation = Quaternion.Euler(-90, 0, 0);
                }
            }
        }
    }

    void OnMouseDown()
    {
        holding = true;

        if(mine != null) {
            mine.hasCard = false;
            mine.cardVal = "";
            mine = null;
        }
    }

    Main.Frame closestFrame()
    {
        float shortestDistance = Vector3.Distance(transform.position, Main.frames[0].obj.transform.position);
        Main.Frame closest = Main.frames[0];

        for(int i = 1; i <= 4; i++)
        {
            if(Vector3.Distance(transform.position, Main.frames[i].obj.transform.position) < shortestDistance)
            {
                shortestDistance = Vector3.Distance(transform.position, Main.frames[i].obj.transform.position);
                closest = Main.frames[i];
            }
        }

        return closest;
    }
}
