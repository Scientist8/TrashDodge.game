using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenuManager : MonoBehaviour
{
    public AudioMixer audioMixer;

    private void Start()
    {
   
        DontDestroyOnLoad(gameObject);
    }

    public void PlayGame()
    {
        PlayerPrefs.SetFloat("PlayerCurrentScore", 0);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);    
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!!");
        Application.Quit();
    }

    //Volume setting
    public void SetVolume(float volume)
    {

        audioMixer.SetFloat("volume", volume);

    }
}
