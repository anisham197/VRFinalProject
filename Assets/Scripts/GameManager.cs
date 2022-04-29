using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager S;

    //Game State
    public bool inLevel0 = true;
    public bool inLevel1 = false;

    public bool timerIsRunningLevel0 = true;
    public float timeRemainingLevel0 = 120;
    public int numOrdersLevel0 = 10;
    public int completedOrdersLevel0 = 0;
    public int[] orderDocketLevel0 = new int[10];
    // new int[] {1, 1, 1, 1, 0, 1, 0, 1, 0, 0};
    public int orderDocketIndexLevel0 = 0;
    public string completionMsgLevel0;

    public bool timerIsRunningLevel1 = false;
    public float timeRemainingLevel1 = 240;
    public int numOrdersLevel1 = 30;
    public int completedOrdersLevel1 = 0;
    public int[] orderDocketLevel1 = new int[30];
    // new int[] {1, 0, 3, 1, 1, 3, 0, 2, 2, 1, 0, 0, 2, 1, 3, 1, 0, 2, 2, 3, 2, 3, 2, 3, 2, 2, 1, 0, 0, 3};
    public int orderDocketIndexLevel1 = 0;
    public string completionMsgLevel1;

    private void Awake() 
    {
        if (S == null) {
            S = this;
        } else if ( S != this) {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        var randNum = new System.Random();
        for (int i = 0; i < orderDocketLevel0.Length; i++) {
            orderDocketLevel0[i] = randNum.Next(0, 2);
        }

        for (int i = 0; i < orderDocketLevel1.Length; i++) {
            orderDocketLevel1[i] = randNum.Next(0, 4);
        }
    }

    // Update is called once per frame
    void Update()
    {
        updateTime();
        TextMeshPro scoreDisplay = GameObject.Find("Score").GetComponent<TextMeshPro>();
        TextMeshPro timeDisplay = GameObject.Find("TimeDisplay").GetComponent<TextMeshPro>();
        
        if (inLevel0) {
            scoreDisplay.text = string.Format("Dishes Served: {0}/{1}", completedOrdersLevel0, numOrdersLevel0);
            timeDisplay.text = string.Format("Time Remaining: {0}", getDisplayTime(timeRemainingLevel0));

            if (timeRemainingLevel0 == 0) {
                completionMsgLevel0 = string.Format("Time's Up! \n You served {0}/{1} dishes." + 
                "\n Level 1 will start in 10 seconds", completedOrdersLevel0, numOrdersLevel0);
                Invoke("LoadLevelTransition", 2.0f);
            }

            // Check completed orders - Win condition
            if (completedOrdersLevel0 == numOrdersLevel0) {
                timerIsRunningLevel0 = false;
                completionMsgLevel0 = string.Format("Congratulations - You Completed Level 0! \n You served all {0} dishes." + 
                "\n Level 1 will start in 10 seconds", completedOrdersLevel0);
                Invoke("LoadLevelTransition", 2.0f);
            }

        } 
        
        if (inLevel1) {
            scoreDisplay.text = string.Format("Dishes Served: {0}/{1}", completedOrdersLevel1, numOrdersLevel1);
            timeDisplay.text = string.Format("Time Remaining: {0}", getDisplayTime(timeRemainingLevel1));

            if (timeRemainingLevel1 == 0) {
                completionMsgLevel0 = string.Format("Time's Up! Game Over! \n Level 1: {0}/{1} dishes.", completedOrdersLevel1, numOrdersLevel1);
                Invoke("LoadLevelTransition", 2.0f);
            }

            // Check completed orders - Win condition
            if (completedOrdersLevel1 == numOrdersLevel1) {
                timerIsRunningLevel1 = false;
                completionMsgLevel1 = string.Format("Congratulations - You Completed Level 1! \n You served all {0} dishes.", completedOrdersLevel1);
                Invoke("LoadLevelTransition", 2.0f);
            }

            
        }
    }

    void updateTime() {
        if (timerIsRunningLevel0)
        {
            if (timeRemainingLevel0 > 0)
            {
                timeRemainingLevel0 -= Time.deltaTime;
            }
            else
            {
                timeRemainingLevel0 = 0;
                timerIsRunningLevel0 = false;
            }
        }

        if (timerIsRunningLevel1)
        {
            if (timeRemainingLevel1 > 0)
            {
                timeRemainingLevel1 -= Time.deltaTime;
            }
            else
            {
                timeRemainingLevel1 = 0;
                timerIsRunningLevel1 = false;
            }
        }
    }

    string getDisplayTime(float timeToDisplay)
    {
        // timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void LoadLevelTransition() {
        SceneManager.LoadScene("LevelEnd");
    }
}
