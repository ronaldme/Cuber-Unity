using UnityEngine;

namespace Assets.Scripts.Game
{
    public class World : MonoBehaviour
    {
        private void Awake()
        {
            int currentLevel = gameObject.name[gameObject.name.Length - 1] - 48;
            
            GameManager.currentLevel = currentLevel;
            GameObject.FindGameObjectWithTag(Tags.background).GetComponent<SpriteRenderer>().sprite =
                Resources.Load<Sprite>("Backgrounds/bg" + currentLevel);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape)) GameManager.LoadMenu();
        }
    }
}