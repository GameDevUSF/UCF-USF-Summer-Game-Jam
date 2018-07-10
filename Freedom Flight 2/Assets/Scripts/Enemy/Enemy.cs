using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int startingHealth = 100;
    private int currentHealth;
    private bool isDead = false;
    private GameObject score_manager;


    // Use this for initialization
    void Start()
    {
        score_manager = GameObject.FindGameObjectWithTag("Score_Manager");
        Destroy(gameObject, 20f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Player_Bullet")
        {
            score_manager.GetComponent<ScoreManager>().Score += 5;
            Destroy(this.gameObject);
        }
    }
}