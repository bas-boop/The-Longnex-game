using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnFruit : MonoBehaviour
{
    private GameObject[] blankTiles;
    private GameObject blankObject;
    private GameObject[] Snake;
    private GameObject[] tiles;
    private int e;
    [SerializeField] private float distanceThreshold;
    private GameObject fruit;
    private void Start()
    {
        fruit = GameObject.Find("Fruit");
        tiles = GameObject.FindGameObjectsWithTag("Panel");
        Snake = GameObject.FindGameObjectsWithTag("Snake");
        IsWithinRange();
    }
    private bool IsWithinRange()
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            tiles[i].SetActive(true);
            for (int i2 = 0; i2 < Snake.Length; i2++)
            {
                if (Vector3.Distance(Snake[i2].transform.position, tiles[i].transform.position) <= distanceThreshold)
                {
                    tiles[i].SetActive(false);
                }
                if (i2 == Snake.Length - 1 && i == tiles.Length - 1)
                {
                    PlaceFruit();
                }
            }
        }
        return true;
    }

    private void PlaceFruit()
    {
        blankTiles = GameObject.FindGameObjectsWithTag("Panel");
        int numberTile = Random.Range(1, blankTiles.Length);
        Debug.Log("random " + numberTile);

        fruit.transform.SetPositionAndRotation(blankTiles[numberTile].transform.position, transform.rotation);

    }

    private void Update()
    {
        for (int i2 = 0; i2 < Snake.Length; i2++)
        {
            if (Vector3.Distance(Snake[i2].transform.position, fruit.transform.position) <= distanceThreshold)
            {
                IsWithinRange();
            }
        }
    }
}
