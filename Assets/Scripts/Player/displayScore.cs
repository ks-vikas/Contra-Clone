using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class displayScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    internal int playerScore;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "SCORE: " + playerScore;
    }
}
