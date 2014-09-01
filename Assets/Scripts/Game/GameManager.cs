using Assets.Scripts.Entities;
using Assets.Scripts.Movement;
using Assets.Scripts.Movement.Android;
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

        public static void EnableAndroid()
        {
            GameObject player = GameObject.FindWithTag(Tags.player);
            player.GetComponent<MoveTouch>().enabled = true;
        }

        public static void Die(Player player)
        {
            health--;

            if (health < 1)
            {
                var go = GameObject.Find("Level").transform.FindChild("RetryQuit").gameObject;
                go.SetActive(true);
                player.gameObject.GetComponent<Move>().death = true;
            }

            if (health < 0)
                Load();
            else
                player.lives[health].enabled = false;
        }
    }
}
