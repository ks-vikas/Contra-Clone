using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] private float health;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    internal void damage(float intensity)
    {
        health -= intensity;

        if (health <= 0)
        {
            anim.SetTrigger("isEnemyDead");
        }
    }

    private void destroyObject()
    {
        Destroy(gameObject);
    }
}
