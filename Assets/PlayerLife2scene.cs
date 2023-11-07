using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife2scene : MonoBehaviour
{

    int lifecount;
    int goldCount;

    Vector2 startPos;
    [SerializeField] public TextMeshProUGUI vidaText;
    [SerializeField] public TextMeshProUGUI goldText;

    // Start is called before the first frame update
    void Start()
    {
        int lifecount = Scorring.lifecountStatic;
        int goldCount = Scorring.lifecountStatic;
        startPos = transform.position;

    }




    // Update is called once per frame
    private void Update()
    {
        if (transform.position.y < -10f)
        {
            Die();
        }
    }

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy body"))
        {
            Die();
        }
        if (collision.gameObject.CompareTag("EnemyHead"))
        {
            Destroy(collision.transform.parent.gameObject);
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GoldCoin"))
        {
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
