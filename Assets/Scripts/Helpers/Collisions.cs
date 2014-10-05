using UnityEngine;

namespace Assets.Scripts.Helpers
{
    public class Collisions
    {
        public static bool IsHit(GameObject obj)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray.origin, ray.direction, out hit))
            {
                if (hit.collider == obj.collider)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsHit2D(GameObject obj)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (Physics2D.Raycast(ray.origin, ray.direction))
            {
                if (hit.collider == obj.collider2D)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
