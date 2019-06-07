using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameObject = null;
    //public GUIText text = null;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "Player")
        {
            //text.text = "You beat the level";
            gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }
}
