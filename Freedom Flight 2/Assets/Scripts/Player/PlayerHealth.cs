using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    private int startingHealth = 100;
    private int currentHealth;

    private bool isDead = false;

    public GameObject health;

    public int StartingHealth
    {
        get { return startingHealth; }
        set { startingHealth = value; }
    }

    public int CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = value; }
    }

    public bool IsDead
    {
        get { return isDead; }
        set { isDead = value; }
    }


    // Use this for initialization
    void Start ()
    {
        currentHealth = startingHealth;
    }
	
	// Update is called once per frame
	void Update ()
    {
        health.GetComponentInChildren<UnityEngine.UI.Slider>().value = currentHealth;

        if (isDead == true)
        {
            SceneManager.LoadScene("Death");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            takeDamage(20);
        }
        else if (collision.gameObject.tag == "Enemy_Bullet")
        {
            takeDamage(5);
        }
    }

    public void takeDamage(int amount)
    {

        currentHealth -= amount;

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;
    }
}
