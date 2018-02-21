using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIElements : MonoBehaviour
{

    public Text score;
    public Text time;
    public GameObject mainPanel;
    public GameObject optionsPanel;
    bool isOptionsActive = false;

    void Update()
    {
        if (Input.GetButtonDown("Cancel") && optionsPanel != null)
            ToggleOptionsPanel();
        if (score != null)
            score.text = "Score: " + PlayerScore.Score;
        if (time != null)
            time.text = "Time: " + Timer.time;
    }

    public void ToggleOptionsPanel()
    {
        if (isOptionsActive == false)
        {
            optionsPanel.SetActive(true);
            isOptionsActive = true;
        }
        else
        {
            optionsPanel.SetActive(false);
            isOptionsActive = false;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(2);
    }
}
  
