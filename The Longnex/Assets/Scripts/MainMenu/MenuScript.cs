using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{

    [SerializeField] public GameObject[] panels;
    [SerializeField] private float location;

    [Header("moving")]
    [SerializeField] private float leftSpeed;
    [SerializeField] private float rightSpeed;

    [Header("looping movement")]
    [SerializeField] private float canMoveLeft;
    [SerializeField] private float canMoveRight;
    [SerializeField] private float originalLeft;
    [SerializeField] private float originalRight;
    [SerializeField] private Vector2 amountLeft;

    private bool moveAllLeft = false;
    private bool moveAllRight = false;
    private bool panel = true;

    private void Start()
    {
        canMoveLeft = 5.5f;
        canMoveRight = 2.7f;
        leftSpeed = 200;
        rightSpeed = 200;
        panels = GameObject.FindGameObjectsWithTag("Games");
        location = 800;
        for (int i = 1; i < panels.Length; i++)
        {
            if (panel)
            {
                panels[i].transform.Translate(Vector2.right * location);
                location += 800;
                if (i == panels.Length - 1)
                {
                    Debug.Log("oke");
                    panels[i] = GameObject.Find("last game");
                    panels[i].tag = ("Games");
                    Debug.Log(panels[i]);
                    panels[i].transform.Translate(Vector2.left * 800);

                    i--;

                    panels[i] = GameObject.Find("Game1 copy");
                    panels[i].tag = ("Games");
                    panels[i].transform.Translate(Vector2.right * location);
                    Debug.Log(panels[i]);
                    placeextrapanels();

                }
            }
        }
        for (int i = 4; i < panels.Length; i++)
        {
            canMoveRight += 4;
        }

    }
    private void Update()
    {
        moving();
        looping();
    }
    private void moving()
    {
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)) && canMoveLeft >= 0)
        {
            canMoveLeft -= Time.deltaTime;
            canMoveRight += Time.deltaTime;
            for (int i = 0; i < panels.Length; i++)
            {
                panels[i].transform.Translate(Vector2.right * Time.deltaTime * rightSpeed);
            }
            
        }
        else if (Input.GetKey(KeyCode.D) && canMoveRight >= 0)
        {
            canMoveLeft += Time.deltaTime;
            canMoveRight -= Time.deltaTime;
            for (int i = 0; i < panels.Length; i++)
            {
                panels[i].transform.Translate(Vector2.left * Time.deltaTime * leftSpeed);
            }
        }
        if (canMoveLeft <= 0 && moveAllRight == false)
        {
            moveAllRight = true;
        }
        if (canMoveRight <= 0 && moveAllLeft == false)
        {
            moveAllLeft = true;
        }
        if (moveAllLeft)
        {
            for (int i = 0; i < panels.Length; i++)
            {
                panels[i].transform.Translate(Vector2.right * location);
                canMoveRight = 0;
                canMoveLeft = 0.0000001f;
                for (int e = 2; e < panels.Length; e++)
                {
                    Debug.Log(e);
                    canMoveRight += 4;
                }
                moveAllLeft = false;

            }
        }
        else if (moveAllRight)
        {
            for (int i = 0; i < panels.Length; i++)
            {
                panels[i].transform.Translate(Vector2.left * location);
                canMoveLeft = 0;
                canMoveRight = 0.0000001f;
                for (int e = 2; e < panels.Length; e++)
                {
                    Debug.Log(e);
                    canMoveLeft += 4;
                }
                moveAllRight = false;

            }
        }
    }
    private void placeextrapanels()
    {
        if (panel)
        {
            panel = false;
            panels = GameObject.FindGameObjectsWithTag("Games");
        }
    }
    private void looping()
    {
        
    }

}
