using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private AudioSource audioSource; 
    public AudioClip press; 

    void Start() { 
        audioSource = GetComponent<AudioSource>(); 
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("GetOut");
    }

    public void QuitGame()
    {
        Application.Quit();
    } 

    public void PlaySound() 
    { 
        audioSource.PlayOneShot(press);
    }
    
}
