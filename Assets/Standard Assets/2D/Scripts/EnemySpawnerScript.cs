using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject enemy;
    public BoxCollider2D mine;
    bool spawned = false;
    public int amountToSpawn;
    void Start()
    {
        mine = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void spawnEnemy()
    {
        if (!spawned)
        {
            for (int i = 0; i < amountToSpawn; ++i)
            {
                Instantiate(enemy, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            }
            spawned = true;
            mine.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Hello world");
        if (collision.tag != "Player"){
            return;
        }
        spawnEnemy();
    }
}
