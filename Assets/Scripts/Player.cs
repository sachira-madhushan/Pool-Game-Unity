using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class Player : MonoBehaviour
{


    [SerializeField] public Slider powerSlider, angleSlider;
    public Text powerText, angleText;
    float powerValue, angleValue;
    public GameObject stick, ballPosition, clone;
    private GameObject ball;
    private Rigidbody ballrigi;
    public Button push;

    void Start()
    {
        GameObject ball = GameObject.FindGameObjectWithTag("Player");
        ballrigi = ball.GetComponent<Rigidbody>();
        powerSlider.onValueChanged.AddListener((v) =>
        {
            powerValue = v;
            powerText.text =Mathf.RoundToInt(powerValue).ToString();


        });

        angleSlider.onValueChanged.AddListener((v) =>
        {
            angleValue = v;
            angleText.text =Mathf.RoundToInt( angleValue).ToString();
            stick.transform.eulerAngles = new Vector3(10.38f, angleValue/10, 0f);

        });
        push.onClick.AddListener(ButtonClick);

    }


    //Button Click
    void ButtonClick()
    {
        float speed = 100f;
        checkTag();
        if (powerValue != 0)
        {
            if (angleValue > 0)
            {
                ballrigi.AddForce(powerValue * speed, 0f, powerValue * speed);
            }
            else if (angleValue == 0)
            {
                ballrigi.AddForce(0f, 0f, powerValue * speed);
            }
            else
            {
                ballrigi.AddForce(-powerValue * speed, 0f, powerValue * speed);
        
           }

            InvokeRepeating("cloneBall", 4f, 0f);

            Destroy(ball, 5f);

        }

        


    }


    //Get Player Object's Rigibody
    void checkTag()
    {
        ball = GameObject.FindGameObjectWithTag("Player");
        ballrigi = ball.GetComponent<Rigidbody>();
    }


    //Clone Player Balls
    void cloneBall()
    {
        Instantiate(clone, ballPosition.transform.position, Quaternion.identity);
    }

    //Destroy Button For 5 till the new ball Created.
    void ButtonActive()
    {

    }
}
