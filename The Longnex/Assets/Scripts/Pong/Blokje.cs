using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = System.Random;

public class Blokje : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    [SerializeField] private float speed;

    [SerializeField] private Vector2 maxSpeed;
    [SerializeField] private Vector2 currentSpeed;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartingForece();
    }

    private void Update()
    {
        currentSpeed = _rb2d.velocity;

        if (currentSpeed == maxSpeed)
        {
            currentSpeed = new Vector2(1.1f ,1.1f);
        }
    }

    private void StartingForece()
    {
        float x = 1f;
        float y = 1f;

        Vector2 direction = new Vector2(x, y);
        _rb2d.velocity = (direction * speed);
    }
}
