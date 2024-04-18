using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class ConversationStarter : MonoBehaviour
{
    public bool playerInRange;
    public GameObject ExclamationMark;
 
    public NPCConversation myConversation;

    private void OnTriggerEnter2D(Collider2D other)
       {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            ExclamationMark.SetActive(true);
       }
       }
        private void OnTriggerExit2D(Collider2D other)
       {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            ExclamationMark.SetActive(false);
            ConversationManager.Instance.EndConversation();
        }
       }

    private void Update()
        {
            if (Input.GetButtonDown("Interact") && playerInRange)
            {
                ConversationManager.Instance.StartConversation(myConversation);
            }
        }

}