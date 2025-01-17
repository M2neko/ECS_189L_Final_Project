﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLaptop : MonoBehaviour
{
    [SerializeField] private GameObject Zee;
    [SerializeField] private GameObject Laptop;
    private GameObject proj;
    private GameObject player;
    private float track;
    private bool left;
    private bool IsShoot;
    private Vector3 pos;

    public void Shoot()
    {
        if (IsShoot)
        {
            return;
        }
        Zee.GetComponent<Animator>().SetBool("1", true);
        pos = Zee.gameObject.transform.position;
        proj = Instantiate(Laptop, pos, Quaternion.identity);
        proj.SetActive(true);
        // Play audio sound
        Zee.GetComponents<AudioSource>()[0].Play();
        player = Zee.GetComponent<Player2Controller>().OtherPlayer();
        if (player.transform.position.x <= Zee.gameObject.transform.position.x)
        {
            left = true;
        }
        else
        {
            left = false;
        }
        IsShoot = true;
    }

    private void Update()
    {
        if (IsShoot)
        {
            track += Time.deltaTime * 5;
            if (track >= 5.0f)
            {
                Zee.GetComponent<Animator>().SetBool("1", false);
            }
            if (track <= 10.0f)
            {
                if (left)
                {
                    proj.gameObject.transform.position = new Vector3(pos.x - track, pos.y, pos.z);
                }
                else
                {
                    proj.gameObject.transform.position = new Vector3(pos.x + track, pos.y, pos.z);
                }
            }
            else
            {
                track = 0.0f;
                proj.SetActive(false);
                IsShoot = false;
                Destroy(proj);
            }
        }
    }
}
