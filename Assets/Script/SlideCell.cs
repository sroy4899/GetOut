using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideCell : MonoBehaviour
{
    private int y, z;
    private Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        int[] yeet = SlidePuzzle.worldToGrid(transform.position.y, transform.position.z);
        y = yeet[0];
        z = yeet[1];
    }

    // Update is called once per frame
    void Update()
    {   
        if(SlidePuzzle.solved) { 
            renderer.material.SetColor("_Color", Color.green);
        }
        if(name.Equals("1") && y == 0 && z == 0) SlidePuzzle.solvers[0] = true;
        else if(name.Equals("1")) SlidePuzzle.solvers[0] = false;
        if(name.Equals("50") && y == 0 && z == 1) SlidePuzzle.solvers[1] = true;
        else if(name.Equals("50")) SlidePuzzle.solvers[1] = false;
        if(name.Equals("11") && y == 0 && z == 2) SlidePuzzle.solvers[2] = true;
        else if(name.Equals("11")) SlidePuzzle.solvers[2] = false;
        if(name.Equals("35") && y == 0 && z == 3) SlidePuzzle.solvers[3] = true;
        else if(name.Equals("35")) SlidePuzzle.solvers[3] = false;
        if(name.Equals("6") && y == 1 && z == 0) SlidePuzzle.solvers[4] = true;
        else if(name.Equals("6")) SlidePuzzle.solvers[4] = false;
        if(name.Equals("15") && y == 1 && z == 1) SlidePuzzle.solvers[5] = true;
        else if(name.Equals("15")) SlidePuzzle.solvers[5] = false;
        if(name.Equals("8") && y == 1 && z == 2) SlidePuzzle.solvers[6] = true;
        else if(name.Equals("8")) SlidePuzzle.solvers[6] = false;
        if(name.Equals("0") && y == 1 && z == 3) SlidePuzzle.solvers[7] = true;
        else if(name.Equals("0")) SlidePuzzle.solvers[7] = false;
        if(name.Equals("9") && y == 2 && z == 0) SlidePuzzle.solvers[8] = true;
        else if(name.Equals("9")) SlidePuzzle.solvers[8] = false;
        if(name.Equals("40") && y == 2 && z == 1) SlidePuzzle.solvers[9] = true;
        else if(name.Equals("40")) SlidePuzzle.solvers[9] = false;
        if(name.Equals("3") && y == 2 && z == 2) SlidePuzzle.solvers[10] = true;
        else if(name.Equals("3")) SlidePuzzle.solvers[10] = false;
        if(name.Equals("5") && y == 2 && z == 3) SlidePuzzle.solvers[11] = true;
        else if(name.Equals("5")) SlidePuzzle.solvers[11] = false;
        if(name.Equals("4") && y == 3 && z == 0) SlidePuzzle.solvers[12] = true;
        else if(name.Equals("4")) SlidePuzzle.solvers[12] = false;
        if(name.Equals("10") && y == 3 && z == 1) SlidePuzzle.solvers[13] = true;
        else if(name.Equals("10")) SlidePuzzle.solvers[13] = false;
        if(name.Equals("12") && y == 3 && z == 2) SlidePuzzle.solvers[14] = true;
        else if(name.Equals("12")) SlidePuzzle.solvers[14] = false;
        
    }

    void OnMouseDown()
    { 
        if (!SlidePuzzle.solved)
        {
            if ((Mathf.Abs(SlidePuzzle.empty_y - y) == 1 && Mathf.Abs(SlidePuzzle.empty_z - z) == 0)
                || (Mathf.Abs(SlidePuzzle.empty_y - y) == 0 && Mathf.Abs(SlidePuzzle.empty_z - z) == 1))
            {
                if (SlidePuzzle.empty_y > y)
                { //empty below 
                    SlidePuzzle.empty_y -= 1;
                    y += 1;
                    transform.Translate(new Vector3(0, -2, 0));
                }
                else if (SlidePuzzle.empty_y < y)
                {
                    SlidePuzzle.empty_y += 1;
                    y -= 1;
                    transform.Translate(new Vector3(0, 2, 0));
                }
                else if (SlidePuzzle.empty_z < z)
                { //empty left
                    SlidePuzzle.empty_z += 1;
                    z -= 1;
                    transform.Translate(new Vector3(0, 0, -2));
                }
                else
                {
                    SlidePuzzle.empty_z -= 1;
                    z += 1;
                    transform.Translate(new Vector3(0, 0, 2));
                }
            }
        }
    }
}
