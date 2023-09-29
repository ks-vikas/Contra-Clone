using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreCalculate : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Coin"))
        {
            player.GetComponent<displayScore>().playerScore = player.GetComponent<displayScore>().playerScore + 10;
            
        }


        if (collision.gameObject.CompareTag("Enemy"))
        {
            player.GetComponent<displayScore>().playerScore = player.GetComponent<displayScore>().playerScore + 50;
            //object is destroyed in EnemyLife script
        }

    }
}
