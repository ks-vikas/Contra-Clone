using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;
    private BoxCollider2D bc;

    [HideInInspector] internal float playerHealth = 100f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap") || collision.gameObject.CompareTag("Enemy"))
        {
            reduceHealth(5f);
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap") || collision.gameObject.CompareTag("Enemy"))
        {
            reduceHealth(0.5f);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {

            reduceHealth(5f);
        }
        if (collision.gameObject.CompareTag("Health"))
        {
            addHealth(10f);
        }

    }

    IEnumerator wait(float time)
    {
        yield return new WaitForSeconds(Time.deltaTime * time);
    }

    private void reduceHealth(float reduce)
    {
        decreaseHealth(reduce);
        if (playerHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        //make player static when die
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");

        //Remove rifle from Player
        GameObject originalGameObject = GameObject.Find("Player");
        GameObject rifle = originalGameObject.transform.GetChild(0).gameObject;
        Destroy(rifle);

        //disable player movement controls when die.
        GetComponent<PlayerMovement>().enabled = false;
        bc.enabled = false;
    }

    private void addHealth(float value)
    {
        playerHealth = Mathf.Clamp(playerHealth + value, 0, 100f); // collected positive health.
    }

    private void decreaseHealth(float value)
    {
        playerHealth = Mathf.Clamp(playerHealth - value, 0, 100f); // collected positive health.
    }
}
