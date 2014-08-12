using System;
using Assets.Scripts.Entities;
using Assets.Scripts.Game;
using UnityEngine;

namespace Assets.Scripts.Items
{
    public class Item : MonoBehaviour
    {
        public TextMesh itemText;
        public AudioSource pickupHealth;

        private void Awake()
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
                    TryPickItUp();
                }
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                TryPickItUp();
            }
        }

        private void TryPickItUp()
        {
            if (!String.IsNullOrEmpty(itemText.text))
            {
                // Check inventory or something
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