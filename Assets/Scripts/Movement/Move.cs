using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Game;
using UnityEngine;

namespace Assets.Scripts.Movement
{
    public class Move : MonoBehaviour
    {
        public bool IsfacingRight { get; set; }
        public bool death;
        public bool touchMovementLeft;
        public bool touchMovementRight;

        private GameObject background;
        private float moveSpeed = 8f;
        private Material rightMaterial;
        private Material leftMaterial;
        private List<GameObject> movingWithPlayer; 

        private void Start()
        {
            IsfacingRight = true;

            rightMaterial = gameObject.renderer.material;
            leftMaterial = Resources.Load<Material>("player_left");

            movingWithPlayer = new List<GameObject>();

            foreach (Transform child in GameObject.FindGameObjectWithTag(Tags.moveWithPlayer).transform.Cast<Transform>().Where(child => child.tag != Tags.background))
            {
                movingWithPlayer.Add(child.gameObject);
            }
        }

        private void Update()
        {
            Movement();

            if (background == null)
            {
                background = GameObject.FindWithTag(Tags.background);
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
                    movingWithPlayer.ForEach(x => x.transform.position += n);
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
                    movingWithPlayer.ForEach(x => x.transform.position += n);
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