using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPad2 : MonoBehaviour
{
    // Start is called before the first frame update
    public Text t;
    public static string entry;
    public string passcode;
    public static bool check;
    public static bool opened; 
    public GameObject tridoor; 
    private Animator tridoorAm;
    void Start()
    {
        t.text = "";
        entry = "";
        check = false;
        opened = false;
        tridoorAm = tridoor.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!opened) {
            t.text = entry;
            if(check) { 
                if(t.text == passcode) { 
                    tridoorAm.SetBool("open", true);
                    opened = true;
                }
                entry = "";
                check = false;
            }
        }
    }
}
