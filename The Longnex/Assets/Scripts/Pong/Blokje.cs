using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = System.Random;

public class Blokje : MonoBehaviour
{
    /// <summary>
    /// Dit is voor de ball (blokje)
    /// Hierin wordt de ball random start ding gedaan
    /// </summary>
    
    private Rigidbody2D _rb2d;
    [SerializeField] private float speed;

    [SerializeField] private Vector2 maxSpeed;
    [SerializeField] private Vector2 currentSpeed;
    
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    private Rigidbody2D _rdp1;
    private Rigidbody2D _rdp2;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _rdp1 = player1.GetComponent<Rigidbody2D>();
        _rdp2 = player2.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        currentSpeed = _rb2d.velocity;

        if (currentSpeed == maxSpeed)
        {
            currentSpeed = new Vector2(1.1f ,1.1f);
        }
    }

    public void RespawnBlokje()
    {
        _rb2d.position = Vector2.zero;
        _rb2d.velocity = Vector2.zero;
        
        _rdp1.position = new Vector2(8,0);
        _rdp1.velocity = Vector2.zero;
        _rdp2.position = new Vector2(-8,0);
        _rdp2.velocity = Vector2.zero;

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
