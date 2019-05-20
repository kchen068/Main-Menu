using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    // Start is called before the first frame update
    //private Box
    private Rigidbody2D rb;
    public float bulletSpeed = 1.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D hitInfo){
        if (hitInfo.tag == "Respawn"){
            return;
        }
        EnemyHealth enemy = hitInfo.GetComponent<EnemyHealth>();
        if (enemy != null){
            enemy.takeDamage(100);
        }
        
        Destroy(this.gameObject);
        
    }
}
