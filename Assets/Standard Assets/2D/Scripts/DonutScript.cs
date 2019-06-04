using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutScript : MonoBehaviour
{
    // Start is called before the first frame update
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
        if (ps != null)
        {
            ps.addStamina(10);
        }

        Destroy(this.gameObject);

    }
}
