using Assets.Scripts.Helpers;
using UnityEngine;

namespace Assets.Scripts.Entities.Enemies
{
    public class Mage : MonoBehaviour
    {
        private bool facingLeft;
        private float timer;
        private float resetTimer = 1f;

        private void Start()
        {
            facingLeft = true;
            timer = Time.time;
        }

        private void Update()
        {
            MoveTowardsPlayer();
        }

        private void MoveTowardsPlayer()
        {
            var rayCastDirection = transform.position + new Vector3(-2f, 0f);

            var leftHit = Physics2D.Raycast(transform.position + Vector3.left, rayCastDirection);
            var rightHit = Physics2D.Raycast(transform.position - Vector3.left, -rayCastDirection);

            if (leftHit.collider != null && leftHit.collider.tag == Tags.player)
            {
                transform.position = Vector3.MoveTowards(transform.position, leftHit.transform.position + new Vector3(1.5f, 0f), 1f * Time.deltaTime);

                var rayCastShoot = transform.position + new Vector3(-1.5f, 0f);
                var withingShootRange = Physics2D.Raycast(transform.position + Vector3.left, rayCastShoot);

                if (!facingLeft)
                {
                    transform.Rotate(new Vector3(0, -180, 0)); 
                    facingLeft = true;
                }

                if (withingShootRange.collider != null)
                {
                    TryShoot();
                }
            }
            if (rightHit.collider != null && rightHit.collider.tag == Tags.player)
            {
                transform.position = Vector3.MoveTowards(transform.position, rightHit.transform.position + new Vector3(-1.5f, 0f), 1f * Time.deltaTime);
                
                if (facingLeft)
                {
                    transform.Rotate(new Vector3(0, 180, 0)); 
                    facingLeft = false;
                }
            }
        }

        private void TryShoot()
        {
            if (!CanShoot()) return;

            var go = (GameObject)Instantiate(Resources.Load<GameObject>(Prefabs.mageAttack));
            go.transform.position = transform.position;
            go.rigidbody2D.AddForce(new Vector2(facingLeft ? -1000f : 1000f, 0f));
        }

        private bool canShoot = true;

        private bool CanShoot()
        {
            if (timer + resetTimer < Time.time && canShoot)
            {
                canShoot = false;
                GetComponent<Animator>().enabled = true;

                return true;
            }
            if (timer + (resetTimer * 2) < Time.time && !canShoot)
            {
                GetComponent<Animator>().enabled = false;
                timer = Time.time;
                canShoot = true;

                return false;
            }
            return false;
        }
    }
}
