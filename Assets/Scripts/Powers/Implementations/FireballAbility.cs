using System.Collections.Generic;
using Assets.Scripts.Helpers;
using Assets.Scripts.Movement;
using Assets.Scripts.Powers.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Powers.Implementations
{
    public class FireballAbility : MonoBehaviour, IAbility
    {
        public int Fireballs { get; private set; }
        public List<GameObject> fireballGameObjects;
        
        private Move move;

        private void Start()
        {
            move = GetComponent<Move>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F) && IsActive())
                UseAbility();
        }

        public void UseAbility()
        {
            var fireBall = (GameObject)Instantiate(Resources.Load<GameObject>(Prefabs.fireball));

            var multiplier = 1;
            if (!move.IsfacingRight)
            {
                multiplier = -1;
            }

            fireBall.transform.position = transform.position + new Vector3(multiplier, 0f, 0f);
            fireBall.transform.rigidbody2D.AddForce(new Vector2(1000f * multiplier, 0f));

            fireballGameObjects[Fireballs - 1].guiTexture.enabled = false;
            Fireballs--;
        }

        public bool IsActive()
        {
            return Fireballs > 0;
        }

        public void Fill()
        {
            Fireballs = 3;
            fireballGameObjects.ForEach(x => x.SetActive(true));
        }
    }
}