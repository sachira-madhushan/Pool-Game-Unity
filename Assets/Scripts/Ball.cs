using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public GameObject ball;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    //change ball tag when collide
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "balls")
        {
            ball.gameObject.tag = "over";
            
            

        }
       
    }

   
}
