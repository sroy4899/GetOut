using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashController : MonoBehaviour
{
    // Start is called before the first frame update 
    private bool isLetter;
    private bool startFlash;
    private float timer = 0.0f;
    private bool first;
    private int index;
    private FlashLight.Flasher[] letterOrder;
    private ArrayList numberOrder;
    private FlashLight.Flasher flasher;
    void Start()
    {
        letterOrder = new FlashLight.Flasher[5];
        numberOrder = new ArrayList();
        

        startFlash = false;
        if (gameObject.CompareTag("LetterActivator")) isLetter = true;
        else isLetter = false;
        index = 0;  
        first = true;
    }

    void Update() { 
        if(first) { 
            letterOrder[0] = (FlashLight.letters[1][0]);
            letterOrder[1] = (FlashLight.letters[1][1]);
            letterOrder[2] = (FlashLight.letters[1][2]);
            letterOrder[3] = (FlashLight.letters[1][3]);
            letterOrder[4] = (FlashLight.letters[1][4]);
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
        if (isLetter) transform.position += new Vector3(-.5f, 0, 0);
        else transform.position += new Vector3(0, 0, .5f);
        yield return new WaitForSeconds(.5f);
        if (isLetter) transform.position -= new Vector3(-.5f, 0, 0);
        else transform.position -= new Vector3(0, 0, .5f);
    }
}
