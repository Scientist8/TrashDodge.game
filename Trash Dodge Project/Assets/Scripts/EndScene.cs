using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScene : MonoBehaviour
{
    public Text scoreDisplay;
    public Text hiScoreDisplay;

    private ScoreManager theScoreManager;


    private void Start()
    {
        
        theScoreManager = FindObjectOfType<ScoreManager>();
        theScoreManager.scoreCount = PlayerPrefs.GetFloat("PlayerCurrentScore");
    }

    public void reTry()
    {
        PlayerPrefs.SetFloat("PlayerCurrentScore", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    public void ending ()
    {
        scoreDisplay.text = "Score: " + Mathf.Round(theScoreManager.scoreCount);
        hiScoreDisplay.text = "HighScore: " + Mathf.Round(theScoreManager.hiScoreCount);

    }

}
