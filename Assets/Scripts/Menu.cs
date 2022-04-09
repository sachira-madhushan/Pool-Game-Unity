using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    private GameObject[] marks;
    public GameObject gameover,button;
    int counter = 0;
    float timecounter;
    public Text timeText,winText;
    bool countTime=true;
    string finalTime;

    void Start()
    {
        marks = GameObject.FindGameObjectsWithTag("marks");
    

        for (int x = 0; x < 3; x++)
        {
            marks[x].SetActive(false);
        }
       
    }


    void Update()
    {
        //count time
        timecounter += Time.deltaTime;
        
        if (countTime == true)
        {
            finalTime=DisplayTime(timecounter);
        }
        
    }

    //check whether the balls collide with goal
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "balls")
        {
            counter++;
            if (counter < 3)
            {
                for (int x = counter; x > 0; x--)
                {

                    marks[x - 1].SetActive(true);
                }
            }
            else if(counter==3)
            {
                countTime = false;
                gameover.SetActive(true);
                button.SetActive(false);
                marks[2].SetActive(true);
                winText.text = "Your Spend " + finalTime + " Time To Complete That Game.\n You Droped All Ball Into The Goal \n\tYou Win";
            }
        }

            
        
        
    }


    //Display the time
    string DisplayTime(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

