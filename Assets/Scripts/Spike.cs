using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public Transform Player;
    public float x;
    public float y;
    private Rigidbody2D rb;
    private Simplemoves codeplayer;

    private void Start()
    {
        rb = Player.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
        }
    }
    /*
    private Simplemoves player;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Simplemoves>();
    }
     
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player")){
            player.Knockback(0.02f, 350, player.transform.position);
        }
    }
    */
}
