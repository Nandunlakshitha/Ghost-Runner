using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Obstacle : MonoBehaviour
{
    public int damage = 1;
    public float speed;

    public GameObject effect;
    public GameObject ExplotionSound;
    

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // player takes damage !
            Instantiate(ExplotionSound, transform.position, Quaternion.identity);
            Instantiate(effect, transform.position, Quaternion.identity);
            other.GetComponent<Player>().health -= damage;
            other.GetComponent<Player>().camAnim.SetTrigger("shake");
            Debug.Log(other.GetComponent<Player>().health);
            Destroy(gameObject);
        }
    }
   

}
