using UnityEngine;

namespace Assets.Scripts.Movement.Android
{
    public class MoveTouch : MonoBehaviour
    {
        public GameObject left;
        public GameObject right;
        
        private Move move;

        private void Start()
        {
            left.SetActive(true);
            right.SetActive(true);
            move = GameObject.Find("Player").GetComponent<Move>();
        }

        private void Update()
        {
            if (Input.touchCount > 0)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray.origin, ray.direction, out hit))
                {
                    if (hit.collider == left.collider)
                    {
                        move.touchMovementLeft = true;
                    }
                    else if (hit.collider == right.collider)
                    {
                        move.touchMovementRight = true;
                    }
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                move.touchMovementLeft = false;
                move.touchMovementRight = false;
            }
        }
    }
}