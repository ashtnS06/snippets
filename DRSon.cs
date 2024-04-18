using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DRSon : MonoBehaviour
{
    public PlayerMovement playerStuff;
    public GameObject DrsText;
    public GameObject DrsTextOn;
    public SpriteRenderer spriteRenderer;
    public Sprite DrsOn;
    public Sprite DrsOff;
    public bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange && playerStuff.accelerationForce < 910 && playerStuff.speedLimit < 974)
        {
            playerStuff.speedLimit = playerStuff.speedLimit + 75f;
            playerStuff.RateOfAccel = 9f;
            
            spriteRenderer.sprite = DrsOn;
            Debug.Log("Drs On");
            DrsText.SetActive(false);
            DrsTextOn.SetActive(true);
        }
    }   
       private void OnTriggerEnter2D(Collider2D other)
       {
        if (other.CompareTag("Player"))
        {
            DrsText.SetActive(true);
            playerInRange = true;
               
        } 
    }

    private void OnTriggerExit2D(Collider2D other)
       {
        if (other.CompareTag("Player"))
        {
                if (DrsTextOn.activeInHierarchy == true)
                {
                    playerStuff.speedLimit = playerStuff.speedLimit - 75f;
                    playerStuff.RateOfAccel = 7f;
                        
                }
             if (playerStuff.accelerationForce > playerStuff.speedLimit)
             {
                playerStuff.accelerationForce = playerStuff.accelerationForce - 50f;
             }       
            spriteRenderer.sprite = DrsOff;
            DrsTextOn.SetActive(false);
            DrsText.SetActive(false);
            playerInRange = false;
            Debug.Log("Drs off");
        } 
    }
}
