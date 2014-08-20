using System.Collections.Generic;
using Assets.Scripts.Game;
using UnityEngine;

namespace Assets.Scripts.Movement
{
    public class Move : MonoBehaviour
    {
        public bool IsfacingRight { get; set; }
        public GameObject left;
        public GameObject right;
        public List<GameObject> movingWithPlayer; 
        public bool death;
        public AudioSource jumpSound;
        public bool touchMovementLeft;
        public bool touchMovementRight;

        private GameObject background;
        private const float moveSpeed = 8f;
        private const float jumpForce = 400f;
        private Material rightMaterial;
        private Material leftMaterial;

        private void Start()
        {
            IsfacingRight = true;

            rightMaterial = gameObject.renderer.material;
            leftMaterial = (Material)Resources.Load("player_left", typeof(Material));
        }

        private void Update()
        {
            Movement();
            Jump();

            if (background == null)
            {
                background = GameObject.FindWithTag(Tags.background);
            }
        }

        private void Jump()
        {
            if (Input.touchCount > 0)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray.origin, ray.direction, out hit))
                {
                    if (hit.collider != left.collider && hit.collider != right.collider)
                    {
                        TryJump();
                    }
                }
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                TryJump();
            }
        }

        private void TryJump()
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

        private void Movement()
        {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) || touchMovementRight)
            {
                if (!IsfacingRight)
                    ChangeFacingDirection();
                
                float playerPos = transform.position.x;
                float camPos = Camera.main.transform.position.x;

                Vector3 n = Vector3.right * Time.deltaTime * moveSpeed;
                transform.position += n;


                if (playerPos >= camPos + 2f && !death)
                {
                    foreach (GameObject go in movingWithPlayer)
                    {
                        go.transform.position += n;
                    }

                    background.transform.position += n / 1.2f;
                }
            }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) || touchMovementLeft)
            {
                if (IsfacingRight)
                    ChangeFacingDirection();

                float playerPos = transform.position.x;
                float camPos = Camera.main.transform.position.x;

                Vector3 n = Vector3.left * Time.deltaTime * moveSpeed;
                transform.position += n;

                if (playerPos <= camPos - 2f && !death)
                {
                    foreach (GameObject go in movingWithPlayer)
                    {
                        go.transform.position += n;
                    }

                    background.transform.position += n / 1.2f;
                }
            }
        }

        public void ChangeFacingDirection()
        {
            gameObject.renderer.material = IsfacingRight ? leftMaterial : rightMaterial;
            IsfacingRight = !IsfacingRight;
        }
    }
}