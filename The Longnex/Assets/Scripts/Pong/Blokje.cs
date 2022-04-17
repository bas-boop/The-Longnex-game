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

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartingForece();
    }

    private void StartingForece()
    {
        float x = 1f;
        float y = 1f;

        Vector2 direction = new Vector2(x, y);
        _rb2d.velocity = (direction * speed);
    }
}
