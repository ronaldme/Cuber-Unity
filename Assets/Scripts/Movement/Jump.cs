using UnityEngine;

namespace Assets.Scripts.Movement
{
    public class Jump : MonoBehaviour
    {
        public GameObject left;
        public GameObject right;
        public AudioSource jumpSound;
        public float jumpForce = 400f;
        private const float distance = 0.1f;

        private void Update()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            if (Input.touchCount > 0)
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                var hit = Physics2D.Raycast(ray.origin, ray.direction);

                if (hit.collider != left.collider2D && hit.collider != right.collider2D)
                {
                    PerformJump();
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

            var vecBack = new Vector3(0.45f, -0.5f);
            var vecForward = new Vector3(-0.45f, -0.5f);
            

            var hitBack = Physics2D.Raycast(transform.position + vecBack, down, distance);
            var hitForward = Physics2D.Raycast(transform.position + vecForward, down, distance);

            if ((hitBack || hitForward) && (hitBack.collider != null || hitForward.collider != null))
            {
                transform.rigidbody2D.AddForce(new Vector2(0f, jumpForce));
                jumpSound.Play();
            }
        }
    }
}