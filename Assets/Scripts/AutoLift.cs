using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoLift : MonoBehaviour
{
    private bool IsDown;
    public float WaitTimes;
    public float speed;

    void Start()
    {
        IsDown = true;
    }

    void Update()
    {
        if (IsDown == true)
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
            StartCoroutine(MoveUp());
        }
    }

    IEnumerator MoveUp()
    {
        yield return new WaitForSeconds(WaitTimes);
        IsDown = false;
        transform.Translate(0, speed * Time.deltaTime, 0);
        yield return new WaitForSeconds(WaitTimes);
        IsDown = true;
    }
}
