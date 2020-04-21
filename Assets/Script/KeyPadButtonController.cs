using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPadButtonController : MonoBehaviour
{
    void OnMouseDown() {
        if(!KeyPad.opened) { 
            if(name == "Clr") { 
                KeyPad.entry = "";
            } 
            else if(name == "Enter") { 
                KeyPad.check = true;
            } 
            else if(KeyPad.entry.Length < 4) { 
                KeyPad.entry += name;
            }
        }
    }
}
