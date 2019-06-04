using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int damage)
    {
        Debug.Log("Taking damage");
        health -= damage;
        SoundManagerScript.playSound("thud");
        if (health <= 0)
        {
            GameObject game = Resources.Load("DonutDrop", typeof(GameObject)) as GameObject;
            Instantiate(game, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
