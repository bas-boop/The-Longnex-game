using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;

    [SerializeField] private float playerSpeed;

    private Rigidbody2D _rdp1;
    private Rigidbody2D _rdp2;

    private void Start()
    {
        _rdp1 = player1.GetComponent<Rigidbody2D>();
        _rdp2 = player2.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        /*if (Input.GetKey(KeyCode.UpArrow))
        {
            player1.transform.position += Vector3.up * playerSpeed;
        }else if (Input.GetKey(KeyCode.DownArrow))
        {
            player1.transform.position -= Vector3.up * playerSpeed;
        }*/
        if (Input.GetKey(KeyCode.UpArrow))
        {
            player1.GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerSpeed);
        }else if (Input.GetKey(KeyCode.DownArrow))
        {
            player1.GetComponent<Rigidbody2D>().AddForce(-Vector2.up * playerSpeed);
        }
        
        /*if (Input.GetKey(KeyCode.W))
        {
            player2.transform.position += Vector3.up * playerSpeed;
        }else if (Input.GetKey(KeyCode.S))
        {
            player2.transform.position -= Vector3.up * playerSpeed;
        }*/
        if (Input.GetKey(KeyCode.W))
        {
            player2.GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerSpeed);
        }else if (Input.GetKey(KeyCode.S))
        {
            player2.GetComponent<Rigidbody2D>().AddForce(-Vector2.up * playerSpeed);
        }
    }
}
