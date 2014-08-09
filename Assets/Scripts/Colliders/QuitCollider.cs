using UnityEngine;

namespace Assets.Scripts.Colliders
{
    public class QuitCollider : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            Application.LoadLevel(0);
        }
    }
}