using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnFruit : MonoBehaviour
{
    private GameObject[] blankTiles;
    private GameObject[] snake;
    private GameObject[] tiles;
    [SerializeField] private float distanceThreshold;
    private SnakeMovement spawn;
    private GameObject fruit;
    private void Start()
    {
        fruit = GameObject.Find("Fruit");
        tiles = GameObject.FindGameObjectsWithTag("Panel");
        snake = GameObject.FindGameObjectsWithTag("Snake");
        spawn = FindObjectOfType<SnakeMovement>();
        IsWithinRange();
    }
    private bool IsWithinRange()
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            tiles[i].SetActive(true);
            for (int i2 = 0; i2 < snake.Length; i2++)
            {
                if (Vector3.Distance(snake[i2].transform.position, tiles[i].transform.position) <= distanceThreshold)
                {
                    snake = GameObject.FindGameObjectsWithTag("Snake");
                    tiles[i].SetActive(false);
                }
                if (i2 == snake.Length - 1 && i == tiles.Length - 1)
                {
                    spawn.spawnBody = true;
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
        for (int i2 = 0; i2 < snake.Length; i2++)
        {
            if (Vector3.Distance(snake[i2].transform.position, fruit.transform.position) <= distanceThreshold)
            {
                IsWithinRange();
            }
        }
    }
}
