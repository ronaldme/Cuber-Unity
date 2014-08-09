using UnityEngine;

namespace Assets.Scripts.Colliders
{
    public class LevelSelectCollider : MonoBehaviour
    {
        public GameObject[] levels;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                var hit = Physics2D.Raycast(ray.origin, ray.direction);

                for (int i = 0; i < levels.Length; i++)
                {
                    if (hit.collider == levels[i].collider2D)
                    {
                        Application.LoadLevel(i + 1);
                    }
                }
            }
        }
    }
}