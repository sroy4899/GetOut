using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidePuzzle : MonoBehaviour
{
    // Start is called before the first frame update
    public static int empty_y, empty_z;
    public static bool[] solvers;
    public static bool solved;
    void Start()
    { 
        empty_y = 3; empty_z = 3;
        solvers = new bool[15];
        for(int i = 0; i < solvers.Length; i++) { 
            solvers[i] = false;
        } 
        solved = false;
    }

    // Update is called once per frame
    void FixedUpdate() 
    {
        bool yeet = true;
        for(int i = 0; i < solvers.Length; i++) { 
            if(solvers[i] == false) yeet = false; 
        } 
        if(yeet) print("SOLVED");
    } 

    public static int[] worldToGrid(float y, float z) { 
        int[] yeet = new int[2]; 
        for(int yi = 8, i = 0; yi > 0; yi -= 2, i += 1) { 
            if(yi == y) yeet[0] = i;  
        } 
        for(int zi = 37, i = 0; zi < 45; zi += 2, i += 1) { 
            if(zi == z) yeet[1] = i;
        }
        return yeet;
    }
}
