using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scoreCalculate : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private long score = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        // This script is not in use

        if (collision.gameObject.CompareTag("Coin"))
        {
            score += 10;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            score += 50;
            //object is destroyed in EnemyLife script
        }

        scoreText.text = "SCORE: " + score;

    }
}
