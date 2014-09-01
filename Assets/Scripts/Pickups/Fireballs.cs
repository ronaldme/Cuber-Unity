using System;
using Assets.Scripts.Game;
using Assets.Scripts.Powers.Implementations;
using UnityEngine;

namespace Assets.Scripts.Pickups
{
    public class Fireballs : MonoBehaviour, IItem
    {
        public TextMesh itemText;
        public AudioSource pickupHealth;
        private FireballAbility ability;

        private void Start()
        {
            ability = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<FireballAbility>();

            itemText.text = "";
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                var hit = Physics2D.Raycast(ray.origin, ray.direction);

                if (hit && hit.collider == collider2D)
                {
                    TryPickup();
                }
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                TryPickup();
            }
        }

        public void TryPickup()
        {
            if (IsPickable())
            {
                if (ability.Fireballs < 3)
                {
                    ability.Fill();
                    Destroy(gameObject.transform.parent.gameObject);
                }
                else
                {
                    itemText.text = "Fireball ability full!";
                }
            }
        }


        public bool IsPickable()
        {
            return !String.IsNullOrEmpty(itemText.text);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.name == "Player")
            {
                itemText.text = GameManager.IsAndroid ? "Click me to pick me up" : "Press E to pick me up";
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.name == "Player")
            {
                itemText.text = "";
            }
        }
    }
}