using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 0;
    public BarUpdater healthBar;
    public GameObject screen = null;
    public bool playerdead = false;

    void Start()
    {
        health = 100000000;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerdead && !screen.active)
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //playerdead = false;
        }
    }
    public void takeDamage(int damage)
    {
        Debug.Log("Player taking damage");
        health -= damage;
        healthBar.decrementBar(damage / 100.0f);
        if (health <= 0)
        {
            screen.SetActive(true);
            Time.timeScale = 0.0f;
            playerdead = true;
        }
    }
    public void incrementHealth(int t)
    {
    }
}
