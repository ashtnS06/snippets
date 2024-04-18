using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneToLoad : MonoBehaviour
{
    
    public GameObject Transiton;
    public SceneTransistion SceneChanger;
    
    
    // Start is called before the first frame update
    void Start()
    {
    
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
            {
                SceneChanger.sceneToLoad = "Dinner Cutscence";
            }
    }
}
