using Assets.Scripts.Game;
using UnityEngine;

namespace Assets.Scripts.Colliders
{
    public class QuitCollider : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                var hit = Physics2D.Raycast(ray.origin, ray.direction);

                if (hit && hit.collider == gameObject.collider2D)
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