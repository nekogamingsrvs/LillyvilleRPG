using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace VoidInc
{
    public class TestPlayer : MonoBehaviour
    {
        private Animator testPlayerAnimator;

        private int testPlayerFacing;

        public Text debugText;

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

            if (Input.GetAxis("Horizontal") < 0)
            {
                testPlayerFacing = 3;
                testPlayerAnimator.SetTrigger("Moving");
                testPlayerAnimator.SetInteger("Facing", testPlayerFacing);
            }
            else if (Input.GetAxis("Horizontal") > 0)
            {
                testPlayerFacing = 1;
                testPlayerAnimator.SetTrigger("Moving");
                testPlayerAnimator.SetInteger("Facing", testPlayerFacing);
            }

            if (Input.GetAxis("Vertical") < 0)
            {
                testPlayerFacing = 0;
                testPlayerAnimator.SetTrigger("Moving");
                testPlayerAnimator.SetInteger("Facing", testPlayerFacing);
            }
            else if (Input.GetAxis("Vertical") > 0)
            {
                testPlayerFacing = 2;
                testPlayerAnimator.SetTrigger("Moving");
                testPlayerAnimator.SetInteger("Facing", testPlayerFacing);
            }
            debugText.text = "Vertical = " + Input.GetAxis("Vertical") + " | Horizontal = " + Input.GetAxis("Horizontal");

            if (!Input.GetButton("Fire1") && Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
            {
                testPlayerAnimator.SetTrigger("Idle");
            }

            gameObject.transform.position += new Vector3(Input.GetAxis("Horizontal") * Speed * Time.deltaTime, Input.GetAxis("Vertical") * Speed * Time.deltaTime, 0);
        }

        void LateUpdate()
        {
        }
    }
}
