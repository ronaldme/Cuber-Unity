using UnityEngine;

namespace Assets.Scripts.Game
{
    public class World : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GameManager.Reset();
                Application.LoadLevel(0);
            }
        }
    }
}