using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    // Start is called before the first frame update
    //public Transform attackPos;
    public LayerMask mask;
    public float attackRange;
    public int attackCoolDown = 0;
    private int wait = 0;
    public int currentWeaponType = 1; //1 = sword, 2 =  knun, 3 = gun, 4 = shooting star
    public int damage;
    public GameObject bulletPrefab;
    public bool facingRight = true;
    void Start()
    {
        
    }

    public void attack(){
        //Debug.Log(Input.GetKey(KeyCode.Q));
        if (wait <= 0 && Input.GetKey(KeyCode.Q))
            {
                gunAttack();
                wait = attackCoolDown;
                return;
                Debug.Log(mask);
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(this.transform.position, attackRange, mask);
                for (int i = 0; i < enemiesToDamage.Length; ++i)
                {
                    Debug.Log(1000000000000);
                    enemiesToDamage[i].GetComponent<EnemyHealth>().takeDamage(10);
                }
                wait = attackCoolDown;
            }
            else
            {
                wait -= 1;
            }
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log("I am being called");
        attack();
    }

    public void gunAttack(){
        var obj = Instantiate(bulletPrefab, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
        
        obj.GetComponent<BulletMovement>().startMoving(facingRight);
    }

    
}
