using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransistion : MonoBehaviour{
    public GameObject ExclamationMark;
    public bool playerInRange;
    public string sceneToLoad;
    public Vector2 playerPosition;
    public VectorValue playerStorage;
    public GameObject fadeInPanel;
    public GameObject fadeOutPanel;
    public float fadeWait;
    
    public void Awake()
    {
        if (fadeInPanel != null)
        {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy (panel, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && playerInRange)
        {
            StartCoroutine(FadeCo());
            
        }
    }  
        private void OnTriggerEnter2D(Collider2D other)
       {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            ExclamationMark.SetActive(true);
            playerStorage.initialValue = playerPosition;
        }
       }
        private void OnTriggerExit2D(Collider2D other)
       {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            ExclamationMark.SetActive(false);
            
        }
       }

    public IEnumerator FadeCo()
    {
        if(fadeOutPanel != null)
        {
            Instantiate(fadeOutPanel, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(fadeWait);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }

}