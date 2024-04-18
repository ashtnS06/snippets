using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    private float elapsedTime;
    private bool isRunning;
    public TMPro.TextMeshProUGUI LapCountText;
    public TMPro.TextMeshProUGUI TimerText;
    public TMPro.TextMeshProUGUI BestLapText;
    public TMPro.TextMeshProUGUI DeltaText;
    int LapCount = 0;
    private float bestLapTime = Mathf.Infinity;

    public GameObject TutObj;

    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = 0f;
        isRunning = false;
        lapFunc();
    }

    // Update is called once per frame
    void Update()
    {
        lapFunc();
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateStopwatchText();
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {      
    
        Debug.Log(other.gameObject.tag);
    if (other.CompareTag("Player"))
    {
        
        
        LapCount++;
        Debug.Log(bestLapTime);
        Debug.Log(elapsedTime);
        
        
        if (elapsedTime < bestLapTime && isRunning)
        {
            bestLapTime = elapsedTime;
            UpdateBestLapText();
        }
        StartStopwatch();
        ResetStopwatch();
    
    
    }
    
    
    }

    void UpdateBestLapText()
    {
        Debug.Log(bestLapTime);
        float minutes = Mathf.FloorToInt(bestLapTime / 60);
        float seconds = Mathf.FloorToInt(bestLapTime % 60);
        float milliseconds = bestLapTime * 1000;
        milliseconds = milliseconds % 1000;
        BestLapText.text = string.Format("Best Lap: {0:00}:{1:00}.{2:000}", minutes, seconds, milliseconds);
    }

    private void lapFunc()
    {
        LapCountText.text = LapCount.ToString();

    }
    void UpdateStopwatchText()
    {
        float minutes = Mathf.FloorToInt(elapsedTime / 60);
        float seconds = Mathf.FloorToInt(elapsedTime % 60);
        float milliseconds = elapsedTime * 1000;
        milliseconds = milliseconds % 1000;
        TimerText.text = string.Format("{0:00}:{1:00}.{2:000}", minutes, seconds, milliseconds);
    
    }

    public void StartStopwatch()
    {
        isRunning = true;
        TutObj.SetActive(false);
    }

    public void StopStopwatch()
    {
        isRunning = false;
    }

    public void ResetStopwatch()
    {
        elapsedTime = 0f;
        UpdateStopwatchText();
    }





}