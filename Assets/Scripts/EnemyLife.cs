using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] private float health = 100f;

    internal void damage(float intensity)
    {
        health -= intensity;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
