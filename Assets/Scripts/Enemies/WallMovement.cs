using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        moveSpeed *= -1;
    }
}
