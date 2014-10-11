using Assets.Scripts.Helpers;
using UnityEngine;

namespace Assets.Scripts.Entities.Enemies
{
    public class MageAttack : MonoBehaviour
    {
        public AudioSource fireballCollision;

        private float currentTime;
        private const float addTime = 2f;

        private void Start()
        {
            currentTime = Time.time;
        }

        private void Update()
        {
            if (currentTime + addTime < Time.time)
            {
                print("Update'");
                Destroy(gameObject);
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == Tags.player)
            {
                print("OnCollisionEnter2D'");
                GameObject.FindGameObjectWithTag(Tags.player).GetComponent<Player>().Die();
                fireballCollision.Play();
            
                renderer.enabled = false;
                renderer.collider2D.enabled = false;
                Destroy(gameObject, 1f);
            }
        }
    }
}
