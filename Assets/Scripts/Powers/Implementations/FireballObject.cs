using Assets.Scripts.Game;
using UnityEngine;

namespace Assets.Scripts.Powers.Implementations
{
    public class FireballObject : MonoBehaviour
    {
        private float currentTime;
        private const float addTime = 1f;

        private void Start()
        {
            currentTime = Time.time;
        }

        private void Update()
        {
            if (currentTime + addTime < Time.time)
            {
                Destroy(gameObject);
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<Destroyable>() != null)
            {
                Destroy(other.gameObject);
            }
            Destroy(gameObject);
        }
    }
}