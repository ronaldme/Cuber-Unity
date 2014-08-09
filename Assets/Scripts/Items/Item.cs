using System;
using Assets.Scripts.Game;
using UnityEngine;

namespace Assets.Scripts.Items
{
    public class Item : MonoBehaviour
    {
        public TextMesh itemText;
        public bool isAndroid;

        private void Awake()
        {
            itemText.text = "";
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
                
                if (hit)
                {
                    if (hit.collider == collider2D)
                    {
                        if (!String.IsNullOrEmpty(itemText.text))
                        {
                            // Check inventory or something
                            if (GameManager.health < 3)
                            {
                                itemText.text = "";
                                GameManager.health++;
                                GameManager.lives[GameManager.health - 1].enabled = true;
                                Destroy(gameObject);
                            }
                            else
                            {
                                itemText.text = "Full health!";
                            }
                        }
                    }
                }
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                if (!String.IsNullOrEmpty(itemText.text))
                {
                    // Check inventory or something
                    if (GameManager.health < 3)
                    {
                        itemText.text = "";
                        GameManager.health++;
                        GameManager.lives[GameManager.health - 1].enabled = true;
                        Destroy(gameObject);
                    }
                    else
                    {
                        itemText.text = "Full health!";
                    }
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.name == "Player")
            {
                if (isAndroid)
                {
                    itemText.text = "Click me to pick me up";
                }
                else
                {
                    itemText.text = "Press E to pick me up";
                }
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