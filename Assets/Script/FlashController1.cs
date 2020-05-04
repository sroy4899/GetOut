using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashController1 : MonoBehaviour
{

    // Start is called before the first frame update
    private bool startFlash;
    private float timer = 0.0f;
    private bool first;
    private int index;
    private FlashLight.Flasher[] numberOrder;
    private FlashLight.Flasher flasher;
    void Start()
    {
        numberOrder = new FlashLight.Flasher[8];
        

        startFlash = false;
        index = 0;  
        first = true;
    }

    void Update() { 
        if(first) { 
            numberOrder[0] = FlashLight.numbers[0][2]; 
            numberOrder[1] = FlashLight.numbers[2][0];
            numberOrder[2] = FlashLight.numbers[0][1];
            numberOrder[3] = FlashLight.numbers[1][2];
            numberOrder[4] = FlashLight.numbers[2][1];
            numberOrder[5] = FlashLight.numbers[1][1];
            numberOrder[6] = FlashLight.numbers[1][0];
            numberOrder[7] = FlashLight.numbers[0][0];
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

            numberOrder[index].Return(); 
            if(index < numberOrder.Length-1) { 
                index++; 
                print(index); 
                numberOrder[index].Flash(); 
                
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
            numberOrder[index].Flash();
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
        transform.position += new Vector3(0, 0, .5f);
        yield return new WaitForSeconds(.5f);
        transform.position -= new Vector3(0, 0, .5f);
    }
}
