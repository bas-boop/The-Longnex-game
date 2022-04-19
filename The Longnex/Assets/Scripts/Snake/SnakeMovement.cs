using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SnakeMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] snake;
    private GameObject[] sides;
    private GameObject head;
    private GameObject body;
    private GameObject bodyParent;
    private GameObject tail;
    [SerializeField] private float waitingTime;
    [SerializeField] private Vector3 directionLeft;
    [SerializeField] private Vector3 directionRight;
    [SerializeField] private float distanceThreshold;
    private bool rotate = false;
    private bool rotateLeft = false;
    private bool rotateRight = false;
    public bool spawnBody = false;
    private void Start()
    {
        sides = GameObject.FindGameObjectsWithTag("Side");
        snake = GameObject.FindGameObjectsWithTag("Snake");
        head = GameObject.Find("Head");
        body = GameObject.Find("Body");
        bodyParent = GameObject.Find("SnakeLongnex");
        tail = GameObject.Find("Tail");
        StartCoroutine(Movement());
    }

    private void Update()
    {
        RotateSnake();
        CollisionWithSide();
    }
    private void RotateSnake()
    {

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            directionLeft.z = 90;
            rotate = true;
            rotateLeft = true;
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
            directionRight.z = -90;
            rotate = true;
            rotateRight = true;
        }
    }

    private void Spawn()
    {
        tail.SetActive(false);
        GameObject clone =  Instantiate(body, tail.transform.position, tail.transform.rotation);
        tail.SetActive(true);
        clone.transform.SetParent(bodyParent.transform, false);
        clone.transform.SetPositionAndRotation(tail.transform.position, tail.transform.rotation);
        clone.transform.localScale = new Vector2(1.5f,1.5f);
        snake = GameObject.FindGameObjectsWithTag("Snake");
        spawnBody = false;
    }

    private IEnumerator Movement()
    {
        
        yield return new WaitForSeconds(waitingTime);
        RotateSnake();
        if (spawnBody) Spawn();
        if (rotate)
        {
            StartCoroutine(Rotate());
            rotate = false;
        }
        tail.transform.position = snake[snake.Length - 2].transform.position;
        for (int i =1; i < snake.Length -1; i++)
        {
            snake[snake.Length-i].transform.position = snake[snake.Length -( i +1)].transform.position;          
        }
        body.transform.position = head.transform.position;
        head.transform.Translate(160, 0, 0);
        StartCoroutine(Movement());
        yield return new WaitForSeconds(0.0001f);
        CollisionWithSelf();
    }

    private void CollisionWithSelf()
    {
        for (int i = 1; i < snake.Length; i++)
        {
            if (Vector3.Distance(head.transform.position, snake[i].transform.position) <= distanceThreshold)
            {
                Debug.Log("collision");
            }
        }
    }
    private void CollisionWithSide()
    {
        for (int i = 0; i < sides.Length; i++)
        {
            for (int i2 = 0; i2 < snake.Length; i2++)
            {
                if (Vector3.Distance(snake[i2].transform.position, sides[i].transform.position) <= distanceThreshold)
                {
                    Debug.Log("dead");
                }
            }
        }
    }

    private IEnumerator Rotate()
    {
        if (rotateLeft) {
            for (int i = 0; i < snake.Length; i++)
            {
                snake[i].transform.Rotate(directionLeft);
                yield return new WaitForSeconds(waitingTime);
            }
            rotate = false;
            rotateLeft = false;
        }
        else if (rotateRight)
        {
            for (int i = 0; i < snake.Length; i++)
            {
                snake[i].transform.Rotate(directionRight);
                yield return new WaitForSeconds(waitingTime);
            }
            rotateRight = false;
        }
    }
}