using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BriefcaseController : MonoBehaviour
{
    public Text box1;
    public Text box2;
    public Text box3;
    public Text box4;
    public Text box5;
    public Text box6; 

    public GameObject b1, b2, b3, b4, b5, b6;
    private Renderer r1, r2, r3, r4, r5, r6, r7;

    public static string text1 = "0";
    public static string text2 = "0";
    public static string text3 = "0";
    public static string text4 = "0";
    public static string text5 = "0";
    public static string text6 = "0";

    public static bool briefcaseCorrect = false;
    public GameObject chest;
    private Animator chestAm;

    private void Start()
    {
        chestAm = chest.GetComponent<Animator>();
        r1 = b1.GetComponent<Renderer>();
        r2 = b2.GetComponent<Renderer>();
        r3 = b3.GetComponent<Renderer>();
        r4 = b4.GetComponent<Renderer>();
        r5 = b5.GetComponent<Renderer>();
        r6 = b6.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!briefcaseCorrect)
        {
            box1.text = text1;
            box2.text = text2;
            box3.text = text3;
            box4.text = text4;
            box5.text = text5;
            box6.text = text6;
        }

        if(box1.text == "1" && box2.text == "3" && box3.text == "5" && box4.text == "4" && box5.text == "0" && box6.text == "7")
        {
            briefcaseCorrect = true; 
            r1.material.SetColor("_Color", Color.green);
            r2.material.SetColor("_Color", Color.green);
            r3.material.SetColor("_Color", Color.green);
            r4.material.SetColor("_Color", Color.green);
            r5.material.SetColor("_Color", Color.green);
            r6.material.SetColor("_Color", Color.green);
            chestAm.SetBool("Open", true);
        }
    }
}
