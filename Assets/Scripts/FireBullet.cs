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
        if(Input.GetButtonDown("Fire1"))
        {
           Instantiate(bullet, fireSource.position, fireSource.rotation);
        }
    }
}
