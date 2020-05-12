using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPadButtonController : MonoBehaviour
{
    private AudioSource audioSource; 
    public AudioClip press; 

    void Start() { 
        audioSource = GetComponent<AudioSource>();
    }
    void OnMouseDown() {
        if(!KeyPad.opened) { 
            if(name == "Clr") { 
                KeyPad.entry = "";
            } 
            else if(name == "Enter") { 
                KeyPad.check = true;
            } 
            else if(KeyPad.entry.Length < 4) { 
                audioSource.PlayOneShot(press, 0.5f);
                KeyPad.entry += name;
            }
        }
    }
}
