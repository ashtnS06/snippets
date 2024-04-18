using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitLane : MonoBehaviour
{
    public PlayerMovement playerStuff;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }   
       private void OnTriggerEnter2D(Collider2D other)
       {
        if (other.CompareTag("Player"))
        {
            playerStuff.speedLimit = 200f;
            
        } 
    }

    private void OnTriggerExit2D(Collider2D other)
       {
        if (other.CompareTag("Player"))
        {
            playerStuff.speedLimit = 900f;
            
        } 
    }
}
