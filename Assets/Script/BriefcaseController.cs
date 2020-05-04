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

    public static string text1 = "0";
    public static string text2 = "0";
    public static string text3 = "0";
    public static string text4 = "0";
    public static string text5 = "0";
    public static string text6 = "0";

    // Update is called once per frame
    void Update()
    {
        box1.text = text1;
        box2.text = text2;
        box3.text = text3;
        box4.text = text4;
        box5.text = text5;
        box6.text = text6;
    }
}
