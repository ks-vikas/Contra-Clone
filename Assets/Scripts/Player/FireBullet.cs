using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField] private Transform fireSource;
    [SerializeField] private GameObject[] bullet;
    internal int currentBullet=0;

        void Update()
    {
        //fire single bullet
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet[currentBullet], fireSource.position, fireSource.rotation);
        }

        //fire in burst mode 
        if (Input.GetButton("Fire2"))
        {
            Instantiate(bullet[currentBullet], fireSource.position, fireSource.rotation);
        }
    }
}
