using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Colliders
{
    public class LevelSelectCollider : MonoBehaviour
    {
        private List<GameObject> levels;
 
        private void Awake()
        {
            levels = new List<GameObject>();

            foreach (Transform child in GameObject.Find("Levels").transform) 
                levels.Add(child.gameObject);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                var hit = Physics2D.Raycast(ray.origin, ray.direction);

                for (int i = 0; i < levels.Count; i++)
                {
                    if (hit.collider == levels[i].collider2D)
                    {
                        Application.LoadLevel(i + 1);
                    }
                }
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
}