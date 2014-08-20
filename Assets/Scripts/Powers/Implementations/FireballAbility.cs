using Assets.Scripts.Movement;
using Assets.Scripts.Powers.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Powers.Implementations
{
    public class FireballAbility : MonoBehaviour, IAbility
    {
        public int fireballs { get; private set; }
        public GameObject[] fireballGameObjects;
        private Move move;

        private void Start()
        {
            move = GetComponent<Move>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F) && IsActive())
            {
                UseAbility();
            }
        }

        public void UseAbility()
        {
            var go = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/Abilities/Fireball"));

            var multiplier = 1;
            if (!move.IsfacingRight)
            {
                multiplier = -1;
            }

            go.transform.position = transform.position + new Vector3(multiplier, 0f, 0f);
            go.transform.rigidbody2D.AddForce(new Vector2(1000f * multiplier, 0f));

            fireballGameObjects[fireballs - 1].guiTexture.enabled = false;
            fireballs--;
        }

        public bool IsActive()
        {
            return fireballs > 0;
        }

        public void Fill()
        {
            fireballs = 3;

            foreach (var fireball in fireballGameObjects)
            {
                fireball.SetActive(true);
            }
        }
    }
}