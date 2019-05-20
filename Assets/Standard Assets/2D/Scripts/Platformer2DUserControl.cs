using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;

        public Transform attackPos;
        public LayerMask mask;
        public float attackRange;
        private int attackCooldown = 0;
        private Weapon weapons;
        private bool test = true;
        private PlayerStamina stamina;
        public GameObject bulletPrefab;
        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
            weapons = new Weapon();
            weapons.attackPos = this.attackPos;
            weapons.mask = this.mask;
            weapons.attackRange = this.attackRange;
            weapons.damage = 10;
            weapons.bulletPrefab = this.bulletPrefab;
            stamina = (PlayerStamina) gameObject.GetComponent<PlayerStamina>();
            //healthBar = GameObject.Find("HealthBar");
            //health = 100;
        }


        private void Update()
        {
            //Debug.Log("Update of platform is called\n");
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }

        }


        private void FixedUpdate()
        {
            //Debug.Log("Fixed update of platform 2d is called\n");
            // Read the inputs.
            weapons.attack();
            if (!test)
            {
                Sprite mySword = (Sprite)Resources.Load("sword", typeof(Sprite));
                Vector3 currentScale = attackPos.localScale;
                attackPos.GetComponent<SpriteRenderer>().sprite = mySword;
                attackPos.localScale = currentScale;
                Debug.Log(attackPos.GetComponent<SpriteRenderer>().sprite);
                test = true;
            }
            bool crouch = Input.GetKey(KeyCode.LeftControl);
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
            //stamina.reduceStamina(1);
            if (h != 0.0f && m_Jump){
                stamina.reduceStamina(1f);
                Debug.Log("first branch");
            }
            else if (h != 0.0f){
                stamina.reduceStamina(0.1f);
            }
            else if (m_Jump){
                stamina.reduceStamina(0.1f);
            }
            m_Character.Move(h, crouch, m_Jump, stamina.emptyStamina());
            m_Jump = false;
        }


    }
}
