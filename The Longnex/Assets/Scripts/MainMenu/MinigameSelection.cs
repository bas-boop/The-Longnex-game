using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameSelection : MonoBehaviour
{
    string currentGame;
    private void Start()
    {
        currentGame = "Other";
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        currentGame = collision.collider.name;
        
        Debug.Log(collision.collider.name);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        currentGame = "Other";
    }
    private void Update()
    {
        switch (currentGame)
        {
            case "Other":
                Debug.Log("Other");
                break;
            case "DressUp":
                Debug.Log("DressUp");
                if (Input.GetKey(KeyCode.E))
                {
                    SceneManager.LoadScene("DressingRoom");
                }
                break;
        }
    }
}
