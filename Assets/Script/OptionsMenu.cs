using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    private AudioSource audioSource; 
    public AudioClip press; 
    
    public void PlaySound() 
    { 
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(press);
    }
}
