using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameSelection : MonoBehaviour
{
    private selectGame currentGame = selectGame.Game1;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKey(KeyCode.E))
        {
            SceneManager.LoadScene("Test");
        }
        Debug.Log(collision.collider.name);
    }
    private void Update()
    {
        switch (currentGame)
        {
            case selectGame.Game1:
                break;
        }
    }
    private enum selectGame
    {
        Game1
    }
}
