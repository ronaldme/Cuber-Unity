using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Game;
using Assets.Scripts.Helpers;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    public class Player : MonoBehaviour
    {
        public bool isAndroid;
        public AudioSource deathSound;
        public Vector3 resetPosition;
        public GUITexture[] lives;

        private List<GameObject> moveWithPlayer;
        private List<Vector3> resetLocations;

        private void Start()
        {
            resetLocations = new List<Vector3>();
            moveWithPlayer = new List<GameObject>();

            var movingWithPlayer = GameObject.FindGameObjectWithTag(Tags.moveWithPlayer);

            foreach (Transform child in movingWithPlayer.transform)
            {
                moveWithPlayer.Add(child.gameObject);
                resetLocations.Add(child.transform.position);
            }

            // Add the player
            moveWithPlayer.Add(gameObject);
            resetLocations.Add(transform.position);

            resetPosition = transform.position;
            GameManager.EnableAndroid(isAndroid);
        }

        private void Update()
        {
            if (transform.position.y < -3.5f) Die();

            Vector3 down = transform.TransformDirection(Vector3.down);
            RaycastHit2D hitGround = Physics2D.Raycast(transform.position + new Vector3(0f, -0.5f), down, 0.65f);

            if (hitGround)
            {
                if (hitGround.collider.tag == Tags.movingGroundHorizontal)
                {
                    foreach (GameObject go in moveWithPlayer)
                    {
                        if (go.tag == Tags.background)
                        {
                            Vector3 n = Vector3.right*Time.deltaTime/1.2f;

                            if (transform.position.x > resetPosition.x)
                            {
                                go.transform.position += n;
                            }
                            else
                            {
                                go.transform.position -= n;
                            }
                        }
                        else
                        {
                            go.transform.parent = hitGround.transform;
                        }
                    }
                }
                else if (hitGround.collider.tag == Tags.movingGroundHorizontal)
                {
                    transform.parent = hitGround.transform;
                }

                resetPosition = transform.position;
            }
            else
            {
                moveWithPlayer.Where(y => y.tag != Tags.background).ToList().ForEach(x => x.transform.parent = null);
            }
        }

        public void Die()
        {
            deathSound.Play();

            for (int i = 0; i < moveWithPlayer.Count; i++)
            {
                moveWithPlayer[i].transform.position = resetLocations[i];
            }

            GameManager.Die(this);
        }
    }
}