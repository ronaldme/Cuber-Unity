using UnityEngine;

namespace Assets.Scripts.Powers
{
    public class Fireball : MonoBehaviour
    {
        private float currentTime;
        private const float addTime = 0.5f;

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
                Destroy(gameObject);
            }
        }
    }
}