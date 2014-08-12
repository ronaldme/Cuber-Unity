using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Powers
{
    public class FireballAbility : MonoBehaviour
    {
        public int fireballs = 1;
        public GameObject[] fireballGameObjects;

        private void Start()
        {
            for (int i = fireballs; i < fireballGameObjects.Length; i++)
            {
                fireballGameObjects[i].guiTexture.enabled = false;
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F) && fireballs > 0)
            {
                var go = (GameObject) Instantiate(Resources.Load<GameObject>("Prefabs/Abilities/Fireball"));
                go.transform.position = transform.position + new Vector3(1f, 0f, 0f);
                go.transform.rigidbody2D.AddForce(new Vector2(1000f, 0f));

                fireballGameObjects[fireballs - 1].guiTexture.enabled = false;
                fireballs--;
            }
        }
    }
}
