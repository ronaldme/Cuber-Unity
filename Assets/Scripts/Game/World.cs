using UnityEngine;

namespace Assets.Scripts.Game
{
    public class World : MonoBehaviour
    {
        private void Awake()
        {
            GameManager.currentLevel = gameObject.name[gameObject.name.Length - 1] - 48;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                GameManager.LoadMenu();
        }
    }
}