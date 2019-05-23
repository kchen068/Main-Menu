using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    private bool FacingRight = true;
    private int frameSkip;
    private int attackCooldown = 0;
    public Transform attackPos;
    public LayerMask mask;
    public float attackRange;
    private bool nearPlayer = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
