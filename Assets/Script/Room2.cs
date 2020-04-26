using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2 : MonoBehaviour
{
    public GameObject door;
    private Animator doorAm;

    // Start is called before the first frame update
    void Start()
    {
        doorAm = door.GetComponent<Animator>();
        doorAm.SetBool("open", true);
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
