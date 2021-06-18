using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{

    public Text scoreDisplay;
    public Text hiScoreDisplay;

    public float scoreCount;
    public float hiScoreCount;    

    public float pointsPerSecond;

    public bool scoreIncreasing;


    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Game Scene")
        {
            PlayerPrefs.SetInt("scoreCount", 0);
        }
        scoreCount = PlayerPrefs.GetFloat("PlayerCurrentScore");
        
        if (PlayerPrefs.HasKey("HighScore"))
        {
            hiScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
    }


    private void Update()
    {
        if (scoreIncreasing)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
            PlayerPrefs.SetFloat("PlayerCurrentScore", scoreCount);
        }        

        if (scoreCount > hiScoreCount)
        {
            hiScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", hiScoreCount);
        }

        scoreDisplay.text = "Score: " + Mathf.Round (scoreCount);
        hiScoreDisplay.text = "HighScore: " + Mathf.Round (hiScoreCount);
    }

    public void AddScore(int pointsToAdd)
    {
        scoreCount += pointsToAdd;
        PlayerPrefs.SetFloat("PlayerCurrentScore", scoreCount);
    }
}