using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPad2 : MonoBehaviour
{
    // Start is called before the first frame update
    public Text t;
    public Material texture;
    public static string entry;
    public GameObject display;
    public string passcode; 
    private Renderer r;
    public static bool check;
    public static bool opened; 
    public GameObject tridoor; 
    private Animator tridoorAm;
    void Start()
    {
        t.text = "";
        r = display.GetComponent<Renderer>();
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
                    r.material.SetColor("_Color", Color.green); 
                } 
                else { 
                    StartCoroutine(Yeet());
                }
                entry = "";
                check = false;
            }
        }
    } 

    IEnumerator Yeet()
    { 
        r.material.SetColor("_Color", Color.red); 
        yield return new WaitForSeconds(1); 
        r.material = texture;
    }
}
