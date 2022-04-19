using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpawnFruit : MonoBehaviour
{
    private GameObject[] blankTiles;
    private GameObject[] snake;
    private GameObject[] tiles;
    [SerializeField] private float distanceThreshold;
    private SnakeMovement spawn;
    private SnakeMovement waitingTime;
    private GameObject fruit;
    [SerializeField] private Sprite fruit1;
    [SerializeField] private Sprite fruit2;
    [SerializeField] private Sprite fruit3;
    [SerializeField]private Sprite fruit4;
    [SerializeField] private Text pointsText;
    private int points;
    private bool start = false;
    private void Start()
    {
        fruit = GameObject.Find("Fruit");
        tiles = GameObject.FindGameObjectsWithTag("Panel");
        snake = GameObject.FindGameObjectsWithTag("Snake");
        spawn = FindObjectOfType<SnakeMovement>();
        waitingTime = FindObjectOfType<SnakeMovement>();
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
                    if (start)
                    {
                        points += 5;
                        spawn.spawnBody = true;
                        waitingTime.waitingTime -= 0.02f;
                    }
                    start = true;
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
        int randomFruit = Random.Range(1, 4);
        if(randomFruit == 1) fruit.GetComponent<Image>().sprite = fruit1;
        else if(randomFruit == 2) fruit.GetComponent<Image>().sprite = fruit2;
        else if(randomFruit == 3) fruit.GetComponent<Image>().sprite = fruit3;
        else if(randomFruit == 4) fruit.GetComponent<Image>().sprite = fruit4;
        fruit.transform.SetPositionAndRotation(blankTiles[numberTile].transform.position, transform.rotation);

    }

    private void Update()
    {
        Debug.Log(points);
        pointsText.text = "Points  " + points;
        for (int i2 = 0; i2 < snake.Length; i2++)
        {
            if (Vector3.Distance(snake[i2].transform.position, fruit.transform.position) <= distanceThreshold)
            {
                IsWithinRange();
            }
        }
    }
}
