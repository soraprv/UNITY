using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOnButton : MonoBehaviour
{
    public GameObject door;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerManager manager = collision.GetComponent<PlayerManager>();
            if (manager)
            {
                if(manager.coinCount > 0)
                {
                    manager.UseCoin();
                    door.SetActive(false);
                }
            }
        }
    }

    ///[SerializeField] private DoorSetActive door;
    /*
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            door.OpenDoor();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            door.CloseDoor();
        }
    }
    */
}
