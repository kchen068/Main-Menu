using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    // Start is called before the first frame update
    //private Box
    private Rigidbody2D rb;
    public float bulletSpeed = -1.0f;
    private bool isMoving = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.velocity = transform.right * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D hitInfo){
        if (!isMoving){
            return;
        }
        Debug.Log(hitInfo.tag);
        if (hitInfo.tag == "Respawn"){
            return;
        }
        EnemyHealth enemy = hitInfo.GetComponent<EnemyHealth>();
        if (enemy != null){
            enemy.takeDamage(15);
        }
        
        Destroy(this.gameObject);
        
    }
    public void startMoving(bool face){
        Debug.Log("BULLET");
         rb = GetComponent<Rigidbody2D>();
        if (face){
            rb.velocity = transform.right * bulletSpeed;
        }
        else{
            Debug.Log("SHOOTING TO THE LEFT");
            transform.Rotate(0.0f, 180.0f, 0.0f, Space.World);
            rb.velocity = transform.right * bulletSpeed;
        }

        isMoving = true;
    }
}
