using System;
using Assets.Scripts.Entities;
using Assets.Scripts.Game;
using UnityEngine;

namespace Assets.Scripts.Items
{
    public class Lives : MonoBehaviour, IItem
    {
        public TextMesh itemText;
        public AudioSource pickupHealth;

        private void Start()
        {
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
                if (GameManager.health < 3)
                {
                    pickupHealth.Play();
                    itemText.text = "";
                    GameManager.health++;
                    GameObject.FindGameObjectWithTag(Tags.player).GetComponent<Player>().lives[GameManager.health - 1]
                        .enabled = true;
                    transform.GetComponent<MeshRenderer>().enabled = false;
                    Destroy(gameObject, 1f);
                }
                else
                {
                    itemText.text = "Full health!";
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