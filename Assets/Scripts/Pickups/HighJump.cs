using System.Collections;
using Assets.Scripts.Game;
using Assets.Scripts.Movement;
using UnityEngine;

namespace Assets.Scripts.Pickups
{
    public class HighJump : Pickup
    {
        private Jump jump;
        public override void TryPickup()
        {
            audioGrab.Play();
            displayText.text = "";

            jump = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<Jump>();
            jump.jumpForce *= 2;

            transform.GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine("DestroyEvent");
        }

        private IEnumerator DestroyEvent()
        {
            while (true)
            {
                yield return new WaitForSeconds(5f);
                jump.jumpForce /= 2;

                Destroy(gameObject);
            }
        }
    }
}