using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField] private Transform fireSource;
    [SerializeField] private GameObject bullet;

        void Update()
    {
        //fire single bullet
        if(Input.GetButtonDown("Fire1"))
        {
           Instantiate(bullet, fireSource.position, fireSource.rotation);
        }

        //fire in burst mode 
        if (Input.GetButton("Fire2"))
        {
            Instantiate(bullet, fireSource.position, fireSource.rotation);
        }
    }
}
