using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BriefcaseButtonController : MonoBehaviour
{
    private AudioSource audioSource; 
    public AudioClip press; 

    void Start() { 
        audioSource = GetComponent<AudioSource>(); 
    }
    private void OnMouseDown()
    {
        if(!BriefcaseController.briefcaseCorrect) audioSource.PlayOneShot(press);
        if(name == "1Up")
        {
            int textVal = int.Parse(BriefcaseController.text1);
            BriefcaseController.text1 = "" + nextVal(textVal, true);
        }

        if (name == "2Up")
        {
            int textVal = int.Parse(BriefcaseController.text2);
            BriefcaseController.text2 = "" + nextVal(textVal, true);
        }

        if (name == "3Up")
        {
            int textVal = int.Parse(BriefcaseController.text3);
            BriefcaseController.text3 = "" + nextVal(textVal, true);
        }

        if (name == "4Up")
        {
            int textVal = int.Parse(BriefcaseController.text4);
            BriefcaseController.text4 = "" + nextVal(textVal, true);
        }

        if (name == "5Up")
        {
            int textVal = int.Parse(BriefcaseController.text5);
            BriefcaseController.text5 = "" + nextVal(textVal, true);
        }

        if (name == "6Up")
        {
            int textVal = int.Parse(BriefcaseController.text6);
            BriefcaseController.text6 = "" + nextVal(textVal, true);
        }

        if (name == "1Down")
        {
            int textVal = int.Parse(BriefcaseController.text1);
            BriefcaseController.text1 = "" + nextVal(textVal, false);
        }

        if (name == "2Down")
        {
            int textVal = int.Parse(BriefcaseController.text2);
            BriefcaseController.text2 = "" + nextVal(textVal, false);
        }

        if (name == "3Down")
        {
            int textVal = int.Parse(BriefcaseController.text3);
            BriefcaseController.text3 = "" + nextVal(textVal, false);
        }

        if (name == "4Down")
        {
            int textVal = int.Parse(BriefcaseController.text4);
            BriefcaseController.text4 = "" + nextVal(textVal, false);
        }

        if (name == "5Down")
        {
            int textVal = int.Parse(BriefcaseController.text5);
            BriefcaseController.text5 = "" + nextVal(textVal, false);
        }

        if (name == "6Down")
        {
            int textVal = int.Parse(BriefcaseController.text6);
            BriefcaseController.text6 = "" + nextVal(textVal, false);
        }
    }

    int nextVal(int curr, bool up)
    {
        if (up)
        {
            return (curr + 1) % 10;
        } else
        {
            int newVal = curr - 1;

            if(newVal < 0)
            {
                return newVal + 10;
            } else
            {
                return newVal;
            }
        }
    }
}
