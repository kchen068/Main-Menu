using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isAmmo = false;
    public bool isStar = false;
    //public GameObject 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag != "Player")
        {
            return;
        }
        PlayerStamina ps = hitInfo.GetComponent<PlayerStamina>();
        PlayerHealth ph = hitInfo.GetComponent<PlayerHealth>();
        WeaponScript obj = hitInfo.GetComponentInChildren<WeaponScript>();
        if (obj == null)
        {
            Debug.Log("O OOO");
        }
        if (ps != null && !isAmmo && !isStar)
        {
            ps.addStamina(10);

        }
        else if (obj != null && isAmmo)
        {
            Debug.Log("here i come");
            int ammo = obj.ammo;
            if (ammo != 5)
            {
                ++obj.ammo;
                obj.ammoBar.incrementBar(20 / 100.0f);
            }
        }
        else if (obj != null && isStar)
        {
            int ammo = obj.starammo;
            if (ammo != 5)
            {
                ++obj.starammo;
                obj.starBar.incrementBar(20 / 100.0f);
            }
        }

        Destroy(this.gameObject);

    }
}
