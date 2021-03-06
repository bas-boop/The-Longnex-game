using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{

    [SerializeField] private GameObject[] panels;
    [SerializeField] private GameObject longnex;
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
        longnex = GameObject.Find("Longnex");
        canMoveLeft = 5.5f;
        canMoveRight = 2.7f;
        leftSpeed = 200;
        rightSpeed = 200;
        panels = GameObject.FindGameObjectsWithTag("Games");
        location = 820;
        for (int i = 1; i < panels.Length; i++)
        {
            if (panel)
            {
                panels[i].transform.Translate(Vector2.right * location);
                location += 820;
                if (i == panels.Length - 1)
                {

                    panels[i] = GameObject.Find("LastGame");
                    panels[i].tag = ("Games");
                    panels[i].transform.Translate(Vector2.left * 820);

                    i--;

                    panels[i] = GameObject.Find("FirstGame");
                    panels[i].tag = ("Games");
                    panels[i].transform.Translate(Vector2.right * location);
                    placeextrapanels();

                }
            }
        }
        for (int i = 4; i < panels.Length; i++)
        {
            canMoveRight += 4.15f;
        }

    }
    private void Update()
    {
        moving();
    }
    private void moving()
    {
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)) && canMoveLeft >= 0)
        {
            canMoveLeft -= Time.deltaTime;
            canMoveRight += Time.deltaTime;
            for (int i = 0; i < panels.Length; i++)
            {
                Debug.Log(longnex);
                longnex.transform.rotation = new Quaternion(0, 0, 0, 0);
                panels[i].transform.Translate(Vector2.right * Time.deltaTime * rightSpeed);
            }
            
        }
        else if (Input.GetKey(KeyCode.D) && canMoveRight >= 0)
        {
            canMoveLeft += Time.deltaTime;
            canMoveRight -= Time.deltaTime;
            for (int i = 0; i < panels.Length; i++)
            {
                longnex.transform.rotation = new Quaternion(0, 180, 0, 0);
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
                    canMoveRight += 4.15f;
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
                    canMoveLeft += 4.15f;
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

}
