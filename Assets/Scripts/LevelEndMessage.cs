using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelEndMessage : MonoBehaviour
{
    private TextMeshPro displayText;
    // Start is called before the first frame update
    void Start()
    {
        displayText = GetComponent<TextMeshPro>();
        if (GameManager.S.inLevel0) {
            Invoke("LoadLevel1", 10.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.S.inLevel0) {
            displayText.text = GameManager.S.completionMsgLevel0;
        }  
        if (GameManager.S.inLevel1) {
            displayText.text = GameManager.S.completionMsgLevel1;
        }
    }

    void LoadLevel1() {
        GameManager.S.timerIsRunningLevel1 = true;
        GameManager.S.inLevel0 = false;
        GameManager.S.inLevel1 = true;
        SceneManager.LoadScene("Level1-Kitchen");
    }
}
