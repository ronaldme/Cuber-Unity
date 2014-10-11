using System.Linq;
using Assets.Scripts.Helpers;
using UnityEngine;

namespace Assets.Scripts.Movement.Android
{
    public class MoveTouch : MonoBehaviour
    {
        public GameObject left;
        public GameObject right;
        public GameObject android;
   
        private Move move;
        private Jump jump;

        private void Start()
        {
            android.SetActive(true);
            move = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<Move>();
            jump = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<Jump>();
        }

        private void Update()
        {
            var input = Input.touches;

            if(input.Length > 0)
            {
                bool isMoving = false;
                bool isJumping = false;

                for (int i = 0; i < Input.touchCount; i++)
                {
                    if ((input[i].phase == TouchPhase.Began || input[i].phase == TouchPhase.Stationary) && !isMoving)
                    {
                        if (Collisions.IsHit(left))
                        {
                            move.MoveLeft();
                            isMoving = true;
                        }
                        else if (Collisions.IsHit(right))
                        {
                            move.MoveRight();
                            isMoving = true;
                        }
                    }
                    if (input[i].phase == TouchPhase.Began && !isJumping)
                    {
                        if (!Collisions.IsHit(left) && !Collisions.IsHit(right))
                        {
                            jump.PerformJump();
                            isJumping = true;
                        }
                    }
                }
            }
        }
    }
}
