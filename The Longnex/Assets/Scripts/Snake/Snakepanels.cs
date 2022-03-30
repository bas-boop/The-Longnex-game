using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Snakepanels : MonoBehaviour
{
    [SerializeField] private GameObject[] tiles;
    private void Start()
    {
        tiles = GameObject.FindGameObjectsWithTag("Panel");
        for (int i = 0; i < 1; i++)
        {
            Debug.Log(tiles[i]);
        }
    }
    private void Update()
    {
        
    }
}