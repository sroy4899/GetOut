﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{ 
    public Texture t;
    public Texture r;
    public class Flasher { 
        GameObject reference;  
        Renderer renderer; 
        Texture tt; 
        Texture rr;
        Color normal, flash;

        public Flasher(GameObject reference, Color normal, Color flash, Texture tt, Texture rr) { 
            this.reference = reference; 
            renderer = this.reference.GetComponent<Renderer>();
            this.tt = tt;
            this.rr = rr;
            //renderer.material.SetTexture("_MainTex", this.rr);
            renderer.material.SetColor("_Color", Color.black);
            this.normal = normal; 
            this.flash = flash;
        } 

        public void Flash() { 
            renderer.material.SetColor("_Color", Color.white);
            renderer.material.SetTexture("_MainTex", tt);
        } 

        public void Return() { 
            renderer.material.SetColor("_Color", Color.black); 
        }
    }
    public GameObject letter; 
    public GameObject number; 
    public static Flasher[][] letters; 
    public static Flasher[][] numbers;

    // Start is called before the first frame update
    void Start()
    { 
        letters = new Flasher[4][]; 
        numbers = new Flasher[4][];
        //create the letters 
        int y = 8;
        int x = -10;
        for(int i = 0; i < 4; i++) { 
            float z = 13;
            int size = 7;
            if(i == 3) { 
                size = 5;
                z = 15.5f;
            } 
            letters[i] = new Flasher[size]; 
            for(int j = 0; j < size; j++) { 
                GameObject curr = Instantiate(letter, new Vector3(x, y, z), Quaternion.Euler(0, 0, 90));
                letters[i][j] = new Flasher(curr, Color.blue, Color.red, t, r);
                z += 2.5f;
            }
            y -= 2;
        } 

        //create the numbers  
        y = 8;
        for(int i = 0; i < 4; i++) { 
            int z = 30; 
            int size = 3;
            x = -8;
            if(i == 3) { 
                size = 1;
                x = -6;
            } 
            numbers[i] = new Flasher[size]; 
            for(int j = 0; j < size; j++) {
                GameObject curr = Instantiate(number, new Vector3(x, y, z), Quaternion.identity);
                numbers[i][j] = new Flasher(curr, Color.blue, Color.red, t, r);
                x += 2;
            }
            y -= 2;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)) { 
            //StartCoroutine(FlashOne());
        }
    } 
}
