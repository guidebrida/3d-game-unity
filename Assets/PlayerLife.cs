using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{

    int lifecount = 3;

    Vector2 startPos;
    [SerializeField] public TextMeshProUGUI vidaText;


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
