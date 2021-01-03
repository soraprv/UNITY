using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacters : MonoBehaviour
{
    public GameObject avatar1, avatar2;
    int whichAvatarIsOn = 1;

    void Start()
    {
        avatar1.gameObject.SetActive(true);
        avatar2.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            SwitchAvatar();
        }
    }

    public void SwitchAvatar()
    {
        switch (whichAvatarIsOn)
        {
            case 1:
                whichAvatarIsOn = 2;
                avatar1.gameObject.SetActive(false);
                avatar2.gameObject.SetActive(true);
                break;
            case 2:
                whichAvatarIsOn = 1;
                avatar1.gameObject.SetActive(true);
                avatar2.gameObject.SetActive(false);
                break;
        }

    }
}

