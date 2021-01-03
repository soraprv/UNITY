using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyAttacker : MonoBehaviour
{
    public int health;
    public GameObject bloodEffect;

    [Header("For Standing")]
    private float moveDirection = 1;
    private bool facingRight = true;
    [SerializeField] Transform groundCheckpoint;
    [SerializeField] float circleRadius;
    [SerializeField] LayerMask groundLayer;
    private bool checkingGround;

    [Header("For JumpAttackng")]
    [SerializeField] float jumpHeight;
    [SerializeField] Transform player;
    [SerializeField] Transform groundCheck;
    [SerializeField] Vector2 boxSize;
    private bool isGrounded;

    [Header("For SeeingPlayer")]
    [SerializeField] Vector2 lineofSite;
    [SerializeField] LayerMask playerLayer;
    private bool canSeePlayer;

    [Header("Other")]
    private Rigidbody2D enemyRB;

    private void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        checkingGround = Physics2D.OverlapCircle(groundCheckpoint.position, circleRadius, groundLayer);
        isGrounded = Physics2D.OverlapBox(groundCheck.position, boxSize, 0, groundLayer);
        canSeePlayer = Physics2D.OverlapBox(transform.position, lineofSite, 0, playerLayer);
        if (canSeePlayer && isGrounded)
        {
            JumpAttack();
        }
        if (health <= 0)
        {
            Instantiate(bloodEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }


    void JumpAttack()
    {
        float distanceFromPlayer = player.position.x - transform.position.x;

        if (isGrounded)
        {
            enemyRB.AddForce(new Vector2(distanceFromPlayer, jumpHeight), ForceMode2D.Impulse);
            FlipTowardsPlayer();
        }
    }

    void FlipTowardsPlayer()
    {
        float playerPosition = player.position.x - transform.position.x;
        if (playerPosition < 0 && facingRight)
        {
            Flip();
        }
        else if (playerPosition > 0 && !facingRight)
        {
            Flip();
        }
    }


    void Flip()
    {
        moveDirection *= -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundCheckpoint.position, circleRadius);

        Gizmos.color = Color.green;
        Gizmos.DrawCube(groundCheck.position, boxSize);

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, lineofSite);
    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("damage Taken !");
    }
}
