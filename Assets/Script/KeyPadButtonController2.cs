using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPadButtonController2 : MonoBehaviour
{
    void OnMouseDown() {
        if(!KeyPad2.opened) { 
            if(name == "Clr") { 
                KeyPad2.entry = "";
            } 
            else if(name == "Enter") { 
                KeyPad2.check = true;
            } 
            else if(KeyPad2.entry.Length < 4) { 
                KeyPad2.entry += name;
            }
        }
    }
}
