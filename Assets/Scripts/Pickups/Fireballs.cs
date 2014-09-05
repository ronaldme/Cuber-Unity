using Assets.Scripts.Game;
using Assets.Scripts.Powers.Implementations;
using UnityEngine;

namespace Assets.Scripts.Pickups
{
    public class Fireballs : Pickup
    {
        private FireballAbility ability;

        private void Awake()
        {
            ability = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<FireballAbility>();
        }

        public override void TryPickup()
        {   
            if (ability.Fireballs < 3)
            {
                ability.Fill();
                Destroy(gameObject.transform.parent.gameObject);
            }
            else
            {
                displayText.text = "Fireball ability full!";
            }
        }
    }
}