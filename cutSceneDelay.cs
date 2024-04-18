using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class cutSceneDelay : MonoBehaviour
{

    public NPCConversation myConversation;
    public float Time;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine (Delay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(Time);
        ConversationManager.Instance.StartConversation(myConversation);
    }

}

