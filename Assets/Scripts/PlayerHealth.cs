using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private bool isTouched;
    private bool isTouchedBullet;
    public int Damage = 1;
    public Transform Frontcheck;
    public float checkObjectRadius;
    public LayerMask whatIsObject;
    public LayerMask whatIsBullet;

    public float waitTime;

    void FixedUpdate()
    {
        isTouched = Physics2D.OverlapCircle(Frontcheck.position, checkObjectRadius, whatIsObject);
        isTouchedBullet = Physics2D.OverlapCircle(Frontcheck.position, checkObjectRadius, whatIsBullet);
    }
    void Update()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {

            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        if (isTouched == true)
        {
            if (waitTime <= 0)
            {
                TakeDamge();
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        if (isTouchedBullet == true)
        {
            if (waitTime <= 0)
            {
                TakeDamgeBullet();
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        if (health <= 0)
        {
            GameOver();
        }
    }
    void TakeDamge()
    {
        health -= 1;
        waitTime = 0.3f;
    }
    void TakeDamgeBullet()
    {
        health -= 1;
        waitTime = 0.1f;
    }
    void GameOver()
    {
        Debug.Log("GAME OVER!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(Frontcheck.position, checkObjectRadius);
    }
}
