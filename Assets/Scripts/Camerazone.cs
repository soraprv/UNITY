using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerazone : MonoBehaviour
{
    public GameObject Virtualcam;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            Virtualcam.SetActive(false);
        }
    }

}
