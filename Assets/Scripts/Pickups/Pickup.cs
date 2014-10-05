using System;
using Assets.Scripts.Game;
using Assets.Scripts.Helpers;
using UnityEngine;

namespace Assets.Scripts.Pickups
{
    public abstract class Pickup : MonoBehaviour
    {
        protected AudioSource audioGrab;
        protected TextMesh displayText;
        
        public abstract void TryPickup();

        private void Start()
        {
            displayText = transform.parent.FindChild("Text").GetComponent<TextMesh>();
            displayText.text = "";

            audioGrab = GetComponent<AudioSource>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && IsPickable())
            {
                if (Collisions.IsHit2D(gameObject))
                {
                    TryPickup();
                }
            }
            else if (Input.GetKeyDown(KeyCode.E) && IsPickable())
            {
                TryPickup();
            }
        }

        public bool IsPickable()
        {
            return !String.IsNullOrEmpty(displayText.text);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == Tags.player)
            {
                displayText.text = GameManager.IsAndroid ? "Click me to pick me up" : "Press E to pick me up";
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.tag == Tags.player)
            {
                displayText.text = "";
            }
        }
    }
}