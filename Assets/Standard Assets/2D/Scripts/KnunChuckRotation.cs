using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnunChuckRotation : MonoBehaviour
{
    // Start is called before the first frame update
    public float var;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.0f, 0.0f, 6 * var * Time.deltaTime);
    }
}
