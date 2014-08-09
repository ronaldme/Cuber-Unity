using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Entities.Obstacles
{
    public class MovingGround : MonoBehaviour
    {
        public float moveTimeForward;
        public float moveTimeBackward;
        public Vector2 pointB;

        private void Awake()
        {
            pointB.x = transform.position.x - pointB.x;
            pointB.y = transform.position.y - pointB.y;
        }

        private void Update()
        {
            Start();
        }

        IEnumerator Start()
        {
            Vector2 pointA = transform.position;
            
            while (true)
            {
                yield return StartCoroutine(MoveObject(pointA, pointB, moveTimeForward));
                yield return StartCoroutine(MoveObject(pointB, pointA, moveTimeBackward));
            }
        }

        IEnumerator MoveObject(Vector2 start, Vector2 end, float time)
        {
            var i = 0.0f;
            var rate = 1.0f / time;
            
            while (i < 1.0f)
            {
                i += Time.deltaTime * rate;
                transform.position = Vector2.Lerp(start, end, i);
                yield return null;
            }
        }
    }
}