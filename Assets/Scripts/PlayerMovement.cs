using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 5;

    private void Update()
    {
        float horizontalSpeed = Input.GetAxis("Horizontal") * Speed;
        float verticalSpeed = Input.GetAxis("Vertical") * Speed;

        transform.position += new Vector3(horizontalSpeed, 0, verticalSpeed) * Time.deltaTime;
    }
}
