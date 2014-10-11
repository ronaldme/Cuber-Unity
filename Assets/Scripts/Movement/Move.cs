using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Game;
using Assets.Scripts.Helpers;
using UnityEngine;

namespace Assets.Scripts.Movement
{
    public class Move : MonoBehaviour
    {
        public bool IsfacingRight { get; set; }
        public bool death;

        private GameObject background;
        private const float moveSpeed = 8f;
        private Material rightMaterial;
        private Material leftMaterial;
        private List<GameObject> movingWithPlayer; 

        private void Start()
        {
            IsfacingRight = true;

            rightMaterial = gameObject.renderer.material;
            leftMaterial = GameManager.currentLevel > 2 ? Resources.Load<Material>("Materials/player_left_pirate") : Resources.Load<Material>("Materials/player_left");

            movingWithPlayer = new List<GameObject>();

            foreach (var child in GameObject.FindGameObjectWithTag(Tags.moveWithPlayer).transform.Cast<Transform>().Where(child => child.tag != Tags.background))
            {
                movingWithPlayer.Add(child.gameObject);
            }

            background = GameObject.FindWithTag(Tags.background);
        }

        private void Update()
        {
            Movement();
        }

        private void Movement()
        {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                MoveRight();
            }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                MoveLeft();
            }
        }

        public void MoveRight()
        {
            if(!IsfacingRight) ChangeFacingDirection();

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

        public void MoveLeft()
        {
            if (IsfacingRight) ChangeFacingDirection();

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

        private void ChangeFacingDirection()
        {
            gameObject.renderer.material = IsfacingRight ? leftMaterial : rightMaterial;
            IsfacingRight = !IsfacingRight;
        }
    }
}