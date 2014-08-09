using UnityEngine;

namespace Assets.Scripts.Movement
{
    public class Rotation : MonoBehaviour
    {
        private void Update()
        {
            transform.Rotate(Vector3.up);
        }
    }
}