using System;
using Assets.Scripts.Game;
using Assets.Scripts.Helpers;
using UnityEngine;

namespace Assets.Scripts.Colliders
{
    public class FinishCollider : MonoBehaviour
    {
        private TextMesh text;
        private bool isWithinCollider;

        private void Start()
        {
            text = GameObject.Find("ItemInfo").GetComponent<TextMesh>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E) && isWithinCollider)
            {
                GameManager.currentLevel++;
                GameManager.Load();
            }
            else if (Input.GetMouseButtonDown(0))
            {
                if (Collisions.IsHit(gameObject) && !String.IsNullOrEmpty(text.text))
                {
                    GameManager.currentLevel++;
                    GameManager.Load();
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

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.tag == Tags.player)
            {
                isWithinCollider = false;
                text.text = "";
            }
        }
    }
}