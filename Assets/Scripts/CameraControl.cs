using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target1;
    public Transform target2;
    public Transform target;
    int targetOn = 1;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private void Start()
    {
        target = target1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            SwitchCamera();
        }
        Vector3 dessiredPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, dessiredPosition, smoothSpeed);
        transform.position = smoothPosition;
    }

    void SwitchCamera()
    {
        switch (targetOn)
        {
            case 1:
                targetOn = 2;
                target = target2;
                break;
            case 2:
                targetOn = 1;
                target = target1;
                break;
        }
    }
}
