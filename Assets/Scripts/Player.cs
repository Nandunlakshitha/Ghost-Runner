using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    private Vector2 targetPos;
    public float Yincrement;
    public float speed;
    public float maxHeight;
    public float minHeight;

    public int health = 3;
    public GameObject effect;
    public TextMeshProUGUI healthDisplay;
    public Animator camAnim;

    public GameObject gameOver;
    public GameObject spawner;
    public GameObject popSound;

    // Update is called once per frame
    void Update()
    {

        healthDisplay.text = health.ToString();

        if (health <= 0)
        {                      
            spawner.SetActive(false);
            gameOver.SetActive(true);
            Destroy(gameObject);
        }



        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight)
        {
            Instantiate(popSound, transform.position, Quaternion.identity);
            camAnim.SetTrigger("shake");
            Instantiate(effect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight)
        {
            Instantiate(popSound, transform.position, Quaternion.identity);
            camAnim.SetTrigger("shake");
            Instantiate(effect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);

        }



    }
}
