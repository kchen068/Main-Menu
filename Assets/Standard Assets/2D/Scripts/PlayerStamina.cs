using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    public float stamina = 0;
    public BarUpdater staminaBar;
    //public float currentSpeed = 1.0f;
    void Start()
    {
        stamina = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void reduceStamina(float reduce)
    {
        //Debug.Log("Player taking damage");
        stamina -= reduce;
        if (stamina <= 0){
            stamina = 0;
        }
        staminaBar.decrementBar(reduce / 100.0f);
        
    }
    public float emptyStamina(){
        if (stamina <= 0){
            return 0.20f;
        }
        else{
            return 1.0f;
        }
    }
    public void addStamina(float add){
        stamina += add;
        if (stamina > 100){
            stamina = 100;
        }
        staminaBar.incrementBar(stamina / 100.0f);
    } 
}
