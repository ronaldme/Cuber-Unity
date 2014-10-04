using System.Collections;
using Assets.Scripts.Helpers;
using Assets.Scripts.Movement;
using UnityEngine;

namespace Assets.Scripts.Pickups
{
    public class HighJump : Pickup
    {
        private Jump jump;
        private float timer;
        private TextTimer textTimer;

        public override void TryPickup()
        {
            audioGrab.Play();
            displayText.text = "";

            jump = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<Jump>();
            jump.jumpForce *= 1.5f;

            gameObject.renderer.enabled = false;

            textTimer = GameObject.Find("AbilityTimer").GetComponent<TextTimer>();
            textTimer.StartTimer();

            StartCoroutine("StopAbility");
        }

        private IEnumerator StopAbility()
        {
            yield return new WaitForSeconds(4f);

            jump.jumpForce /= 1.5f;
            textTimer.Stop();
            Destroy(gameObject);
        }
    }
}