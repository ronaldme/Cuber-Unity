using UnityEngine;

namespace Assets.Scripts.Game
{
    public static class GameManager
    {
        public static int levelId = 1;
        public static int health = 3;
        public static GUITexture[] lives;

        public static bool IsAndroid { get; set; }

        public static void Reset()
        {
            levelId = 1;
            health = 3;
        }

    }
}
