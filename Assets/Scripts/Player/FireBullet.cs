using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField] private Transform fireSource;
    [SerializeField] private GameObject[] bullet;
    internal int currentBullet=0;
    private float ShotOffset = 0.5f;

        void Update()
    {
        //fire single bullet
        if (Input.GetButtonDown("Fire1"))
        {

            Instantiate(bullet[currentBullet], fireSource.position, fireSource.rotation);
            if (currentBullet == 1 )
            {
                Instantiate(bullet[currentBullet], new Vector2(fireSource.position.x, fireSource.position.y + ShotOffset), fireSource.rotation);
                Instantiate(bullet[currentBullet], new Vector2(fireSource.position.x, fireSource.position.y - ShotOffset), fireSource.rotation);
            }
            if (currentBullet == 2)
            {
                Instantiate(bullet[currentBullet], new Vector2(fireSource.position.x - ShotOffset, fireSource.position.y), fireSource.rotation);
                Instantiate(bullet[currentBullet], new Vector2(fireSource.position.x + ShotOffset, fireSource.position.y), fireSource.rotation);
                Instantiate(bullet[currentBullet], new Vector2(fireSource.position.x + 2*ShotOffset, fireSource.position.y), fireSource.rotation);
            }

        }

        //fire in burst mode 
        if (Input.GetButton("Fire2"))
        {
            Instantiate(bullet[currentBullet], fireSource.position, fireSource.rotation);
            if (currentBullet == 1)
            {
                Instantiate(bullet[currentBullet], new Vector2(fireSource.position.x, fireSource.position.y + ShotOffset), fireSource.rotation);
                Instantiate(bullet[currentBullet], new Vector2(fireSource.position.x, fireSource.position.y - ShotOffset), fireSource.rotation);
            }
        }

    }
}
