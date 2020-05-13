using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscapeTimer : MonoBehaviour
{
    // Start is called before the first frame update
    public Text timer;
    public Text loseText; 
    public GameObject player;
    public Text winText;
    public Light lt;
    private float time;
    private bool won = true;
    private bool finished = false;

    void Start()
    {
        time = 3600;
        loseText.text = "";
        winText.text = "";
        timer.text = "60:00"; 
    }

    void FixedUpdate() 
    {
        if (!finished)
        {
            if (time >= 1)
            {
                time -= Time.deltaTime;
                float minutes = Mathf.Floor(time / 60);
                float seconds = Mathf.Floor(time % 60);
                if (seconds < 10)
                {
                    timer.text = minutes + ":0" + seconds;
                }
                else { timer.text = minutes + ":" + seconds; }
            }
            else
            {
                timer.color = Color.red;
                timer.text = "0:00";
                won = false;
            }

            if (player.transform.position.z <= -11)
            {
                finished = true;
                lt.intensity = 0;

                if (won)
                {
                    timer.color = Color.green;
                    winText.text = "Dear child, you have done the impossible. \nYou are the first person to finish my tasks, and now you are my champion.\nOnwards we go! The name of the secret place, which you are now worthy of: Casino of Yeeticus";
                }
                else
                {
                    loseText.text = "Dear child, you have failed me.";
                }

                StartCoroutine(ShutDown());
            }
        } 
    }
    IEnumerator ShutDown()
    {
        yield return new WaitForSeconds(14f);
        Application.Quit();
    }
} 


