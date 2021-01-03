using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour
{
    public GameObject Door;
    int DoorCheck = 1;
    public Transform SwitchCheck;
    public float checkRadius;
    public LayerMask whatIsPlayer;
    private bool InArea;

    void Start()
    {
        Door.gameObject.SetActive(true);
    }

    private void FixedUpdate()
    {
        InArea = Physics2D.OverlapCircle(SwitchCheck.position, checkRadius, whatIsPlayer);
    }

    void Update()
    {
        if (InArea == true)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                SwitchDoor();
            }
        }
    }

    public void SwitchDoor()
    {
        switch (DoorCheck)
        {
            case 1:
                DoorCheck = 2;
                Door.gameObject.SetActive(false);
                break;
            case 2:
                DoorCheck = 1;
                Door.gameObject.SetActive(true);
                break;
        }
    }
}
