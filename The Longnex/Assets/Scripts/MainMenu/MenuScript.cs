using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private GameObject[] panels;
    [SerializeField] private float location;
    [SerializeField] private float leftSpeed = 200;
    [SerializeField] private float rightSpeed = 200;

    private void Start()
    {
        panels = GameObject.FindGameObjectsWithTag("Games");
        location = 750;
        for (int i = 1; i < panels.Length; i++)
        {
            panels[i].transform.Translate(Vector2.right * location);
            location += 750;
            Debug.Log("works");
        }
        
        Debug.Log(panels.Length);
    }
    private void Update()
    {
        moving();
    }
    private void moving()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            for (int i = 0; i < panels.Length; i++)
            {
                panels[i].transform.Translate(Vector2.right * Time.deltaTime * rightSpeed);
            }
            
        }
        else if (Input.GetKey(KeyCode.D))
        {
            for (int i = 0; i < panels.Length; i++)
            {
                panels[i].transform.Translate(Vector2.left * Time.deltaTime * leftSpeed);
            }
        }
    }
}
