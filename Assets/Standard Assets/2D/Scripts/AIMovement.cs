using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public bool FacingRight = false;
    private int frameSkip = 0;
    private int attackCooldown = 20;
    public int waitBetweenAttack = 20;
    public Transform attackPos;
    public LayerMask mask;
    public float attackRange;
    private bool nearPlayer = false;
    public int damage = 10;
    public float speed = 1.6f;
    public Quaternion ogRotation;
    public int weaponType = 1;
    public float distance = 1.5f;
    //public GameObject bulletPrefrab;
    void Start()
    {
        //attackPos = this.transform.GetChild(0).GetChild(0).GetChild(0);
        player = GameObject.Find("CharacterRobotBoy");
        ogRotation = this.transform.rotation;
        if (player == null)
        {
            Debug.Log("STOOPPP");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (weaponType == 1 || weaponType == 2)
        {
            attack();
        }
        else if (weaponType == 3 || weaponType == 4)
        {
            gunAttack();
        }
        
        if (frameSkip > 0)
        {
            --frameSkip;
            return;
        }
        float player_x = player.transform.position.x;
        checkFace(player_x);
        if (Vector2.Distance(transform.position, player.transform.position) > distance)
        {
            //Debug.Log("I am being called");
            nearPlayer = false;

            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed);
            //animator.SetFloat("Speed", Mathf.Abs(x_initial));
            //rigidbody2D.velocity = new Vector2(x_initial * 10.0f, rigidbody2D.velocity.y);
        }
        else
        {
            //animator.SetFloat("Speed", 0.0f);
            nearPlayer = true;
            Debug.Log("i am near");
        }

        frameSkip = 10;
    }

    public void attack()
    {
        if (attackCooldown <= 0 && nearPlayer)
        {
            //attackPos.transform.Rotate(0.0f, 0.0f, -90.0f, Space.Self);
            if (weaponType == 1)
            {
                Transform gameObject = this.transform.GetChild(0);
                gameObject.transform.Rotate(0.0f, 0.0f, 90.0f, Space.Self);
            }
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, mask);
            for (int i = 0; i < enemiesToDamage.Length; ++i)
            {
                enemiesToDamage[i].GetComponent<PlayerHealth>().takeDamage(damage);
            }
            attackCooldown = waitBetweenAttack;
        }
        else
        {
            if (attackCooldown >= 0)
            {
                attackCooldown -= 1;
                if (attackCooldown <= 0)
                {
                    if (weaponType == 1 || weaponType == 2)
                    {
                        resetRotation();
                    }
                }
            }

        }
    }

    private void gunAttack()
    {
        if (attackCooldown <= 0 && nearPlayer)
        {
            float offset = 0.5f;
            if (!FacingRight)
            {
                offset *= -1;
            }

            GameObject bull;
            GameObject obj = null;
            if (weaponType == 3)
            {
                bull = Resources.Load("Bullet", typeof(GameObject)) as GameObject;
                obj = Instantiate(bull, new Vector2(attackPos.transform.position.x + offset, attackPos.transform.position.y), Quaternion.identity);
            }
            else
            {
                bull = Resources.Load("ShootingStar Variant", typeof(GameObject)) as GameObject;
                obj = Instantiate(bull, new Vector2(attackPos.transform.position.x + offset, attackPos.transform.position.y), Quaternion.identity);
            }
            //Instantiate(game, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
            //Destroy(this.gameObject);
            //var obj = Instantiate(bull, new Vector2(attackPos.transform.position.x + offset,attackPos.transform.position.y), Quaternion.identity);
            Debug.Log("i AM BEING CALLED");
            SoundManagerScript.playSound("gunshot");
            obj.GetComponent<BulletMovement>().forPlayer = true;
            obj.GetComponent<BulletMovement>().byEnemy = true;
            obj.GetComponent<BulletMovement>().startMoving(FacingRight);
            attackCooldown = waitBetweenAttack;
        }
        else
        {
            attackCooldown -= 1;
        }
    }

    private void checkFace(float player_x)
    {
        if (player_x - transform.position.x < 0.0f)
        {
            if (FacingRight)
            {
                Flip();
            }
        }
        else
        {
            if (!FacingRight)
            {
                Flip();
            }
        }
    }
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        FacingRight = !FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    //private void FixedUpdate()
    //{
    //    //Debug.Log("Fixed update of platform 2d is called\n");
    //    // Read the inputs.
    //    //if (attackCooldown <= 0 && nearPlayer)
    //    //{
    //    //    attackPos.transform.Rotate(0.0f, 0.0f, -90.0f, Space.Self);
    //    //    Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, mask);
    //    //    for (int i = 0; i < enemiesToDamage.Length; ++i)
    //    //    {
    //    //        enemiesToDamage[i].GetComponent<PlayerHealth>().takeDamage(damage);
    //    //    }
    //    //    attackCooldown = waitBetweenAttack;
    //    //}
    //    //else
    //    //{
    //    //    if (attackCooldown >= 0)
    //    //    {
    //    //        attackCooldown -= 1;
    //    //        if (attackCooldown <= 0)
    //    //        {
    //    //            if (weaponType == 1 || weaponType == 2)
    //    //            {
    //    //                resetRotation();
    //    //            }
    //    //        }
    //    //    }

    //    //}
    //}
    public void resetRotation()
    {
        Transform gameObject = this.transform.GetChild(0);
        gameObject.transform.rotation = Quaternion.Slerp(attackPos.transform.rotation, ogRotation, Time.time * 1.0f);
    }
}
