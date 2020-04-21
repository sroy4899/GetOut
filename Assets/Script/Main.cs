using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public class Frame
    {
        public GameObject obj;
        public bool hasCard;
        public string cardVal;

        public Frame(GameObject obj)
        {
            this.obj = obj;
            this.hasCard = false;
            this.cardVal = "";
        }
    }

    public GameObject frame1;
    public GameObject frame2;
    public GameObject frame3;
    public GameObject frame4;
    public GameObject frame5;
    public static Frame[] frames;
    private ArrayList correctCards;
    public GameObject chest; 
    private Animator chestAm;
    private bool chestFinished;
    public GameObject door; 
    private Animator doorAm; 
    

    // Start is called before the first frame update
    void Start()
    {
        chestFinished = false;
        doorAm = door.GetComponent<Animator>();
        chestAm = chest.GetComponent<Animator>();
        frames = new Frame[5];
        frames[0] = new Frame(frame1);
        frames[1] = new Frame(frame2);
        frames[2] = new Frame(frame3);
        frames[3] = new Frame(frame4);
        frames[4] = new Frame(frame5);

        correctCards = new ArrayList();
        correctCards.Add("2D");
        correctCards.Add("2H");
        correctCards.Add("2S");
        correctCards.Add("10C");
        correctCards.Add("10D");
    }

    // Update is called once per frame
    void Update()
    { 
        if(!chestFinished) { 
            int count = 0;
            for(int i = 0; i <= 4; i++)
            {
                if (frames[i].hasCard && correctCards.Contains(frames[i].cardVal))
                {
                    count++;
                }
            }      

            if(count == 5)
            {
                chestFinished = true;
                //chestAm.SetBool("Open", true);
            }
        }
        
    } 

}
