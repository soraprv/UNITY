using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatetoOpenDoor : MonoBehaviour
{
    public GameObject Portal;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "KeyTouch")
        {
            Portal.SetActive(true);
        }
    }
}
