using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace VoidInc
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class TestPlayer : MonoBehaviour
    {
        private Animator testPlayerAnimator;

        private int testPlayerFacing;

        public Text debugText;
        
        public LayerMask collisionLayer;

        public float Speed;

        // Use this for initialization
        void Start()
        {
            testPlayerAnimator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButton("Fire1"))
            {
                testPlayerAnimator.SetTrigger("Attacking");
            }

            if (Input.GetAxis("Vertical") < 0)
            {
                testPlayerFacing = 0;
                testPlayerAnimator.SetTrigger("Moving");
                testPlayerAnimator.SetInteger("Facing", testPlayerFacing);
                if(!Physics2D.Linecast(new Vector2(transform.position.x - 7, transform.position.y - 8), new Vector2(transform.position.x + 7, transform.position.y - 8), collisionLayer))
                {
                    gameObject.transform.position += new Vector3(0, Input.GetAxis("Vertical") * Speed * Time.deltaTime, 0);
                }
            }
            else if (Input.GetAxis("Vertical") > 0)
            {
                testPlayerFacing = 2;
                testPlayerAnimator.SetTrigger("Moving");
                testPlayerAnimator.SetInteger("Facing", testPlayerFacing);
                if(!Physics2D.Linecast(new Vector2(transform.position.x - 7, transform.position.y + 8), new Vector2(transform.position.x + 7, transform.position.y + 8), collisionLayer))
                {
                    gameObject.transform.position += new Vector3(0, Input.GetAxis("Vertical") * Speed * Time.deltaTime, 0);
                }
            }

            if (Input.GetAxis("Horizontal") < 0)
            {
                testPlayerFacing = 3;
                testPlayerAnimator.SetTrigger("Moving");
                testPlayerAnimator.SetInteger("Facing", testPlayerFacing);
                if(!Physics2D.Linecast(new Vector2(transform.position.x - 8, transform.position.y - 7), new Vector2(transform.position.x - 8, transform.position.y + 7), collisionLayer))
                {
                    gameObject.transform.position += new Vector3(Input.GetAxis("Horizontal") * Speed * Time.deltaTime, 0, 0);
                }
            }
            else if (Input.GetAxis("Horizontal") > 0)
            {
                testPlayerFacing = 1;
                testPlayerAnimator.SetTrigger("Moving");
                testPlayerAnimator.SetInteger("Facing", testPlayerFacing);
                if(!Physics2D.Linecast(new Vector2(transform.position.x + 8, transform.position.y - 7), new Vector2(transform.position.x + 8, transform.position.y + 7), collisionLayer))
                {
                    gameObject.transform.position += new Vector3(Input.GetAxis("Horizontal") * Speed * Time.deltaTime, 0, 0);
                }
            }

            debugText.text = "Vertical = " + Input.GetAxis("Vertical") + " | Horizontal = " + Input.GetAxis("Horizontal");

            if (!Input.GetButton("Fire1") && Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
            {
                testPlayerAnimator.SetTrigger("Idle");
            }
        }

        void LateUpdate()
        {
        }
    }
}
