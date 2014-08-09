using UnityEngine;

namespace Assets.Scripts.Colliders
{
    public class RetryCollider : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            Application.LoadLevel(1);
        }
    }
}