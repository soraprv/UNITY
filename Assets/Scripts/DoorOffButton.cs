using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOffButton : MonoBehaviour
{
    public GameObject door;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerManager manager = collision.GetComponent<PlayerManager>();
            if (manager)
            {
                door.SetActive(true);
            }
        }
    }
}
