using UnityEngine;

namespace Assets.Scripts.Game
{
    public static class GameManager
    {
        public static int currentLevel = 1;
        public static int health = 3;

        public static bool IsAndroid { get; set; }

        public static void Load()
        {
            health = 3;
            Application.LoadLevel(currentLevel);
        }

        public static void LoadMenu()
        {
            health = 3;
            Application.LoadLevel(0);
        }
    }
}
