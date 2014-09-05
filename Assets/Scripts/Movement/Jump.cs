using UnityEngine;

namespace Assets.Scripts.Movement
{
    public class Jump : MonoBehaviour
    {
        public GameObject left;
        public GameObject right;
        public AudioSource jumpSound;
        public float jumpForce = 400f;

        private void Update()
        {
            CheckInput();
        }

        private void CheckInput()
        {
            if (Input.touchCount > 0)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray.origin, ray.direction, out hit))
                {
                    if (hit.collider != left.collider && hit.collider != right.collider)
                    {
                        PerformJump();
                    }
                }
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                PerformJump();
            }
        }

        private void PerformJump()
        {
            Vector3 down = transform.TransformDirection(Vector3.down);

            Vector3 vecBack = new Vector3(0.45f, -0.5f);
            Vector3 vecForward = new Vector3(-0.45f, -0.5f);

            float dis = 0.1f;

            var hitBack = Physics2D.Raycast(transform.position + vecBack, down, dis);
            var hitForward = Physics2D.Raycast(transform.position + vecForward, down, dis);

            if ((hitBack || hitForward) && (hitBack.collider != null || hitForward.collider != null))
            {
                transform.rigidbody2D.AddForce(new Vector2(0f, jumpForce));
                jumpSound.Play();
            }
        }
    }
}