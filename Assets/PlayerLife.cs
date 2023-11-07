using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{

    int lifecount = 3;
    int goldCount = 0;

    Vector2 startPos;
    [SerializeField] public TextMeshProUGUI vidaText;
    [SerializeField] public TextMeshProUGUI goldText;


    public static PlayerLife Instance;


    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        if(transform.position.y < -10f)
        {
            Die();
        }
    }

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy body")) {
            Die();
        }
        if (collision.gameObject.CompareTag("EnemyHead"))
        {
            Destroy(collision.transform.parent.gameObject);
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GoldCoin")){
            goldCount++;
            goldText.text = "Moedas: " + goldCount;
            Destroy(other.gameObject);
        }


        if (other.gameObject.CompareTag("faze1"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (other.gameObject.CompareTag("Trofeu"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }



    }

    void Die()
    {
        lifecount--;
        vidaText.text = "Vidas: " + lifecount;
        Console.WriteLine(lifecount.ToString());
        if (lifecount >= 0)
        {
            transform.position = startPos;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }



}
