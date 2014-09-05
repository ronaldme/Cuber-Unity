﻿using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Game;
using Assets.Scripts.Movement;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    public class Player : MonoBehaviour
    {
        public bool isAndroid;
        public AudioSource deathSound;
        public Vector3 prePosition;
        public GUITexture[] lives;
        public List<GameObject> moveWithPlayer;

        private List<Vector3> resetLocations;

        private void Start()
        {
            GameManager.IsAndroid = isAndroid;
            resetLocations = new List<Vector3>();

            moveWithPlayer.ForEach(x => resetLocations.Add(x.transform.position));
            prePosition = transform.position;

            if (isAndroid) GameManager.EnableAndroid();
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

                            if (transform.position.x > prePosition.x)
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

                prePosition = transform.position;
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