using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public int scoreToGive;

    private ScoreManager theScoreManager;

    public float speed;

    //public Text scoreDisplay;

    public GameObject effect;

    public GameObject explosionSound;

    private void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
    }

    private void Update()
    {
        //scoreDisplay.text = score.ToString();

        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        //increasing score and effects and sound
        {
            theScoreManager.AddScore(scoreToGive);

            FindObjectOfType<AudioManager>().Play("coin sound");
            Instantiate(effect, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }


}
