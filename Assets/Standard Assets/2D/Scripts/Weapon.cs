using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform attackPos;
    public LayerMask mask;
    public float attackRange;
    public int attackCoolDown = 0;
    public int currentWeaponType = 1; //1 = sword, 2 =  knun, 3 = gun, 4 = shooting star
    public int damage;
    void Start()
    {
        
    }

    public void attack(){
        if (attackCoolDown <=0 && Input.GetKey(KeyCode.Q))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, mask);
                for (int i = 0; i < enemiesToDamage.Length; ++i)
                {
                    //Debug.Log(1000000000000);
                    enemiesToDamage[i].GetComponent<EnemyHealth>().takeDamage(10);
                }
                attackCoolDown = 10;
            }
            else
            {
                attackCoolDown -= 1;
            }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
