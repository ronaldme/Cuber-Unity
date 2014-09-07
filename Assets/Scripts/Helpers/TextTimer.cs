using UnityEngine;

namespace Assets.Scripts.Helpers
{
    /// <summary>
    /// With a interval of 5f
    /// </summary>
    public class TextTimer : MonoBehaviour
    {
        public string text;
        private float interval = 5f;
        public bool start;

        private TextMesh textMesh;

        private void Start()
        {
            textMesh = GetComponent<TextMesh>();
        }

        private void Update()
        {
            if (start) textMesh.text = text + (interval - Time.time).ToString("##.#");
        }

        public void StartTimer()
        {
            start = true;
        }

        public void Stop()
        {
            start = false;
            textMesh.text = "";
        }
    }
}
