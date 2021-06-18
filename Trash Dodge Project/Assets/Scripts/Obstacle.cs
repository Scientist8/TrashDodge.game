using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damage = 1;
    public float speed;

    public GameObject effect;

    public GameObject explosionSound;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            //player takes damage
        {
            FindObjectOfType<AudioManager>().Play("car crash");
            Instantiate(effect, transform.position, Quaternion.identity);

            other.GetComponent<Player>().health -= damage;
            Destroy(gameObject);
        }
    }
}
