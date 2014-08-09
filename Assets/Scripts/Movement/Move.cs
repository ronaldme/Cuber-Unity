using System.Collections.Generic;
using Assets.Scripts.Game;
using UnityEngine;

namespace Assets.Scripts.Movement
{
    public class Move : MonoBehaviour
    {
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
                Vector3 down = transform.TransformDirection(Vector3.down);
                var hitGround = Physics2D.Raycast(transform.position + new Vector3(0f, -0.5f), down, 0.1f);

                if (hitGround && hitGround.collider.name == "Ground")
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;

                    if (Physics.Raycast(ray.origin, ray.direction, out hit))
                    {
                        if (hit.collider != left.collider && hit.collider != right.collider)
                        {
                            transform.rigidbody2D.AddForce(new Vector2(0f, jumpForce));
                            jumpSound.Play();
                        }
                    }
                    else
                    {
                        transform.rigidbody2D.AddForce(new Vector2(0f, jumpForce));
                        jumpSound.Play();
                    }
                }
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                Vector3 down = transform.TransformDirection(Vector3.down);
                var hitGround = Physics2D.Raycast(transform.position + new Vector3(0f, -0.5f), down, 0.1f);

                if (hitGround && hitGround.collider.name == "Ground")
                {
                    transform.rigidbody2D.AddForce(new Vector2(0f, jumpForce));
                    jumpSound.Play();
                }
            }
        }

        private void Movement()
        {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) || touchMovementRight)
            {
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
    }
}