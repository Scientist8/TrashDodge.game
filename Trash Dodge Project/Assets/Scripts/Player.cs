using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Player : MonoBehaviour
{
    private Vector2 targetPos;
    public float Yincrement;
    public float speed;
    public float maxHeight;
    public float minHeight;

    public int health = 3;

    public GameObject effect;
    public Text healthDisplay;

    public GameObject gameOver;

    private ScoreManager theScoreManager;

    

    private void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
    }

    private void Update()
    {
        //health display and death event
        healthDisplay.text ="HP: " + health.ToString();
        
        if (health <= 0)
        {
            theScoreManager.scoreIncreasing = false;

            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Destroy(gameObject);
        }

        //player movement
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
                 
    }

    public void moveUp()
    {
        if (transform.position.y < maxHeight)
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);

        }
    }
    public void moveDown()
    {
        if (transform.position.y > minHeight)
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
        }
    }
}
