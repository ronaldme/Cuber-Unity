using Assets.Scripts.Game;
using Assets.Scripts.Helpers;
using UnityEngine;

namespace Assets.Scripts.Colliders
{
    public class QuitCollider : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Collisions.IsHit2D(gameObject))
                    GameManager.LoadMenu();
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.tag == Tags.player)
                GameManager.LoadMenu();
        }
    }
}