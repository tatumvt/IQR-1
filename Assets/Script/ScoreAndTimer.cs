using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreAndTimer : MonoBehaviour
{
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreTextPOP;
    public GameObject gameobjScore;
    public GameObject endOfGameCanvas;
    public string scoreName;
    public int score;

    private void Start()
    {
        Time.timeScale = 1;
        score = 0;
        timerIsRunning = true;
        InvokeRepeating("OutputTime", 1f, 1f);  //1s delay, repeat every 1s
    }

    void OutputTime()
    {
        if (timerIsRunning)
        {
            score++;
        }
    }

    void Update()
    {
        //TEMP
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteAll();
        }

        scoreText.text = score.ToString();

        if (timerIsRunning)
        {

            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                int temp = PlayerPrefs.GetInt(scoreName);
                endOfGameCanvas.SetActive(true);
                if (temp <= score)
                {
                    gameobjScore.SetActive(true);
                    PlayerPrefs.SetInt(scoreName, score);
                }
                scoreTextPOP.text = score.ToString();

                Time.timeScale = 0;
                timerIsRunning = false;
                DisplayTime(-1);
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void RemoveTime(float time)
    {
        timeRemaining -= time;
    }

    public void AddScore(int _score)
    {
        score += _score;
    }
}