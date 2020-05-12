using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashController : MonoBehaviour
{
    // Start is called before the first frame update 
    private bool startFlash;
    private float timer = 0.0f;
    private bool first;
    private int index;
    private AudioSource audioSource; 
    public AudioClip buttonPress;
    private FlashLight.Flasher[] letterOrder;
    private FlashLight.Flasher flasher;
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
        letterOrder = new FlashLight.Flasher[8];        

        startFlash = false;
        index = 0;  
        first = true;
    }

    void Update() { 
        if(first) { 
            letterOrder[0] = (FlashLight.letters[1][3]);
            letterOrder[1] = (FlashLight.letters[0][4]);
            letterOrder[2] = (FlashLight.letters[3][3]);
            letterOrder[3] = (FlashLight.letters[1][4]);
            letterOrder[4] = (FlashLight.letters[2][3]);
            letterOrder[5] = (FlashLight.letters[1][4]);
            letterOrder[6] = (FlashLight.letters[1][1]);
            letterOrder[7] = (FlashLight.letters[1][5]); 

            first = false;
        }
    }
    void FixedUpdate()
    {
        if (startFlash)
        {
            timer += Time.deltaTime;

        }
        if(timer > 1.0f) { 

            letterOrder[index].Return(); 
            if(index < letterOrder.Length-1) { 
                index++; 
                letterOrder[index].Flash(); 
                
            }
            else { 
                startFlash = false;
            }
            timer = 0;
        }
    }


    void OnMouseDown()
    {
        if(!startFlash) { 
            startFlash = true;
            index = 0;
            audioSource.PlayOneShot(buttonPress);
            StartCoroutine(Press());
            letterOrder[index].Flash();
        }
    }

    void FlashLetters()
    {

    }

    void FlashNumbers()
    {

    }


    IEnumerator Press()
    {
        transform.position += new Vector3(-.5f, 0, 0);
        yield return new WaitForSeconds(.5f);
        transform.position -= new Vector3(-.5f, 0, 0);
    }
}
