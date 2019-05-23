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
    private int weaponSwitch = 0;
    public int currentWeaponType = 1; //1 = sword, 2 =  knun, 3 = gun, 4 = shooting star
    public int damage;
    public GameObject bulletPrefab;
    public bool facingRight = true;
    private List<Sprite> weaponList;
    public Quaternion ogRotation;
    void Start()
    {
        weaponList = new List<Sprite>();
        weaponList.Add((Sprite)Resources.Load("sword", typeof(Sprite)));
        weaponList.Add((Sprite)Resources.Load("knun", typeof(Sprite)));
        weaponList.Add((Sprite)Resources.Load("gun", typeof(Sprite)));
        weaponList.Add((Sprite)Resources.Load("star", typeof(Sprite)));
        //currentWeaponType = 1;
        ogRotation = this.transform.rotation;
        loadWeapon();
    }

    public void attack(){
        //Debug.Log(Input.GetKey(KeyCode.Q));
        if (wait <= 0 && Input.GetKeyDown(KeyCode.Q))
        {
            if (currentWeaponType == 1)
            {
                swordAttack();
            }
            else if (currentWeaponType == 2)
            {
                knunAttack();
            }
            else if (currentWeaponType == 3)
            {
                gunAttack();
            }
            else if (currentWeaponType == 4)
            {
                shootingStarAttack();
            }
        }
        else
        {
            if (wait >= 0)
            {
                wait -= 1;
            }
            else
            {
                if (currentWeaponType == 1 || currentWeaponType == 2)
                {
                    resetRotation();
                }
            }
        }

        if (weaponSwitch <= 0 && Input.GetKeyDown(KeyCode.S))
        {
            if (currentWeaponType == 4)
            {
                currentWeaponType = 1;
            }
            else
            {
                ++currentWeaponType;
            }
            loadWeapon();
        }
        else
        {
            if (weaponSwitch >= 0)
            {
                weaponSwitch -= 1;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log("I am being called");
        attack();
    }

    public void gunAttack(){
        float offset = 0.5f;
        if (!facingRight)
        {
            offset *= -1;
        }
        var obj = Instantiate(bulletPrefab, new Vector2(this.transform.position.x + offset, this.transform.position.y), Quaternion.identity);
        Debug.Log("i AM BEING CALLED");
        obj.GetComponent<BulletMovement>().startMoving(facingRight);
        wait = attackCoolDown;
    }

    public void knunAttack()
    {
        this.transform.Rotate(0.0f, 0.0f, -90.0f, Space.Self);
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(this.transform.position, attackRange, mask);
        for (int i = 0; i < enemiesToDamage.Length; ++i)
        {
            //Debug.Log(1000000000000);
            enemiesToDamage[i].GetComponent<EnemyHealth>().takeDamage(10);
        }
        wait = attackCoolDown;
        //this.transform.rotation = Quaternion.Slerp(this.transform.rotation, ogRotation, Time.time * 1.0f);
    }

    public void shootingStarAttack()
    {

    }


    public void swordAttack()
    {
        this.transform.Rotate(0.0f, 0.0f, -90.0f, Space.Self);
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(this.transform.position, attackRange, mask);
        for (int i = 0; i < enemiesToDamage.Length; ++i)
        {
            //Debug.Log(1000000000000);
            enemiesToDamage[i].GetComponent<EnemyHealth>().takeDamage(15);
        }
        wait = attackCoolDown;
        //this.transform.rotation = Quaternion.Slerp(this.transform.rotation, ogRotation, Time.time * 1.0f);
    }

    public void loadWeapon()
    {
        Vector3 gunScale = new Vector3(0.5f, 0.5f, 1.0f);
        Vector3 otherScale = new Vector3(0.3f, 0.3f, 1.0f);
        //Vector3 currentScale = this.transform.localScale;
        this.transform.GetComponent<SpriteRenderer>().sprite = weaponList[currentWeaponType - 1];
        //this.transform.localScale = currentScale;
        if (currentWeaponType == 1)
        {
            attackCoolDown = 20;
            this.transform.localScale = otherScale;
            //this.transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self);
        }
        else if (currentWeaponType == 2)
        {
            attackCoolDown = 10;
            this.transform.localScale = otherScale;
            //this.transform.rotation = Quaternion.Slerp(this.transform.rotation, ogRotation, Time.time * 1.0f);
        }
        else if (currentWeaponType == 3)
        {
            attackCoolDown = 10;
            this.transform.localScale = gunScale;
            this.transform.Rotate(0.0f, -180.0f, 45.0f, Space.Self);
        }
        else if (currentWeaponType == 4)
        {
            attackCoolDown = 5;
            this.transform.localScale = otherScale;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, ogRotation, Time.time * 1.0f);
        }
            weaponSwitch = 15;
    }

    public void resetRotation()
    {
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, ogRotation, Time.time * 1.0f);
    }


}
