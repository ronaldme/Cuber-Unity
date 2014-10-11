using System.Collections.Generic;
using Assets.Scripts.Helpers;
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
                for (int i = 0; i < levels.Count; i++)
                {
                    if (Collisions.IsHit2D(levels[i]))
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