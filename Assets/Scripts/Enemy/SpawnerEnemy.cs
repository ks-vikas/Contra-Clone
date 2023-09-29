using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private GameObject[] enemiesReference;
   //[SerializeField] private Transform leftPosition;
    [SerializeField] private Transform rightPosition;
    [SerializeField] private int numberOfEnemies = 5;

    private GameObject spawnedEnemy;
    private GameObject player;

    private int randIndex;
   // private int randSide;
    private float playerPosX;
    private float spawnerPosX;
    private bool isSpawned = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //StartCoroutine(SpawnEnemy());
    }

    private void Update()
    {
        playerPosX = player.transform.position.x;
        spawnerPosX = gameObject.transform.position.x;
        //Debug.Log(spawnerPosX);

        if (!isSpawned && (spawnerPosX - playerPosX < 25f) && (playerPosX < spawnerPosX))
        {
            isSpawned = true;
            StartCoroutine(SpawnEnemy());
        }
    }
    IEnumerator SpawnEnemy()
    {
        
        while (numberOfEnemies-- > 0)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));
            randIndex = Random.Range(0, enemiesReference.Length);
           // randSide = Random.Range(0, 2);

            spawnedEnemy = Instantiate(enemiesReference[randIndex]);

            spawnedEnemy.transform.position = rightPosition.position;
            spawnedEnemy.GetComponent<EnemyRunLeft>().speed = Random.Range(4, 10);
            spawnedEnemy.transform.localScale = new Vector3(spawnedEnemy.transform.localScale.x, spawnedEnemy.transform.localScale.y, spawnedEnemy.transform.localScale.z);


            /*            if (randSide == 0)
                        { //left side 
                            spawnedEnemy.transform.position = leftPosition.position;
                            spawnedEnemy.GetComponent<EnemyRunLeft>().speed = -Random.Range(4, 10);


                        }
                        else
                        {
                            //right side
                            spawnedEnemy.transform.position = rightPosition.position;
                            spawnedEnemy.GetComponent<EnemyRunLeft>().speed = Random.Range(4, 10);
                            spawnedEnemy.transform.localScale = new Vector3(-spawnedEnemy.transform.localScale.x, spawnedEnemy.transform.localScale.y, spawnedEnemy.transform.localScale.z);

                        }*/
        }

    }
}
