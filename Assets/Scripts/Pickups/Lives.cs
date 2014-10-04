using Assets.Scripts.Entities;
using Assets.Scripts.Game;
using Assets.Scripts.Helpers;
using UnityEngine;

namespace Assets.Scripts.Pickups
{
    public class Lives : Pickup
    {
        public override void TryPickup()
        {
            if (GameManager.health < 3)
            {
                audioGrab.Play();
                displayText.text = "";
                GameManager.health++;
                GameObject.FindGameObjectWithTag(Tags.player).GetComponent<Player>().lives[GameManager.health - 1]
                    .enabled = true;
                transform.GetComponent<MeshRenderer>().enabled = false;
                Destroy(gameObject, 1f);
            }
            else
            {
                displayText.text = "Full health!";
            }
        }
    }
}