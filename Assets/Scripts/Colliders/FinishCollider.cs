using System;
using Assets.Scripts.Game;
using UnityEngine;

namespace Assets.Scripts.Colliders
{
    public class FinishCollider : MonoBehaviour
    {
        public TextMesh text;

        private bool isWithinCollider;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E) && isWithinCollider)
            {
                GameManager.levelId++;
                Application.LoadLevel(GameManager.levelId);
            }
            else if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                var hit = Physics2D.Raycast(ray.origin, ray.direction);

                if (hit && hit.collider == collider2D && !String.IsNullOrEmpty(text.text))
                {
                    GameManager.levelId++;
                    Application.LoadLevel(GameManager.levelId);
                }
            }
        }
        
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == Tags.player)
            {
                isWithinCollider = true;
                text.text = GameManager.IsAndroid ? "Click the flag to start next level!" : "Press E to start next level!";
            }
        }

        void OnTriggerLeave2D(Collider2D other)
        {
            if (other.tag == Tags.player)
            {
                isWithinCollider = false;
                text.text = "";
            }
        }
    }
}