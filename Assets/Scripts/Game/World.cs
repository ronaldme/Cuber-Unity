using UnityEngine;

namespace Assets.Scripts.Game
{
    public class World : MonoBehaviour
    {
        private void Awake()
        {
            
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.LoadLevel(0);
            }
        }
    }
}