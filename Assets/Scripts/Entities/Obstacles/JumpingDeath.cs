using Assets.Scripts.Game;
using UnityEngine;

namespace Assets.Scripts.Entities.Obstacles
{
    public class JumpingDeath : MonoBehaviour
    {
        public float jumpingTime = 2.5f;
        public float delay;
        private float startTime;

        private void Awake()
        {
            startTime = Time.time;
        }

        private void FixedUpdate()
        {
            if (startTime + jumpingTime + delay < Time.time)
            {
                gameObject.transform.rigidbody2D.AddForce(new Vector2(0f, 400f));
                startTime = Time.time;
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.tag == Tags.player)
            {
                other.gameObject.GetComponent<Player>().Die();
            }
        }
    }
}
