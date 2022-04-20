using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SnakeMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] snake;
    private GameObject[] sides;
    private GameObject head;
    private GameObject body;
    private GameObject bodyParent;
    private GameObject tail;
    private GameObject endScreen;
    public float waitingTime;
    [SerializeField] private int speed = 160; 
    [SerializeField] private Vector3 directionLeft;
    [SerializeField] private Vector3 directionRight;
    [SerializeField] private float distanceThreshold;
    private bool rotate = false;
    private bool rotateLeft = false;
    private bool rotateRight = false;
    public bool spawnBody = false;
    [SerializeField] private Sprite normal;
    [SerializeField] private Sprite tails;
    [SerializeField] private Sprite left;
    [SerializeField] private Sprite right;
    private void Start()
    {
        endScreen = GameObject.Find("EndScreen 1");
        endScreen.SetActive(false);
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
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            directionRight.z = -90;
            rotate = true;
            rotateRight = true;
        }
    }

    private void Spawn()
    {
        tail.SetActive(false);
        GameObject clone = Instantiate(body, tail.transform.position, tail.transform.rotation);
        tail.SetActive(true);
        clone.transform.SetParent(bodyParent.transform, false);
        clone.transform.SetPositionAndRotation(tail.transform.position, tail.transform.rotation);
        clone.transform.localScale = new Vector2(1.5f, 1.5f);
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
        for (int i = 1; i < snake.Length - 1; i++)
        {
            snake[snake.Length - i].transform.position = snake[snake.Length - (i + 1)].transform.position;
        }
        body.transform.position = head.transform.position;
        head.transform.Translate(speed, 0, 0);
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
                speed = 0;
                endScreen.SetActive(true);
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
                    speed = 0;
                    endScreen.SetActive(true);
                }
            }
        }
    }
    //private IEnumerator RotateCorrect()
    //{
    //    body.transform.rotation = head.transform.rotation;
    //    yield return new WaitForSeconds(waitingTime);
    //    for (int i = 1; i < snake.Length - 1; i++)
    //    {
    //        snake[snake.Length - i].transform.rotation = snake[snake.Length - (i + 1)].transform.rotation;
    //        yield return new WaitForSeconds(waitingTime);
    //    }

    //    tail.transform.rotation = snake[snake.Length - 2].transform.rotation;


    //}
    private IEnumerator Rotate()
    {
        if (rotateLeft) {
            for (int i = 0; i < snake.Length; i++)
            {
                snake[i].transform.Rotate(directionLeft);
                //StartCoroutine(RotateCorrect());
                if (i >= 1) 
                {
                    for (int i2 = 1; i2 < snake.Length; i2++)
                    {
                        tail.GetComponent<Image>().sprite = tails;
                        if (snake[snake.Length -1] == tail == false)
                        {
                            for (int i3 = 0; i3 < snake.Length; i3++)
                            {
                                snake[i].transform.Rotate(directionLeft);
                                tail.GetComponent<Image>().sprite = tails;
                            }
                        }

                    }
                    yield return new WaitForSeconds(waitingTime);
                    snake[i].GetComponent<Image>().sprite = normal;
                    tail.GetComponent<Image>().sprite = tails;
                }

            }
            rotate = false;
            rotateLeft = false;
        }
        else if (rotateRight)
        {
            //StartCoroutine(RotateCorrect());
            for (int i = 0; i < snake.Length; i++)
            {
                snake[i].transform.Rotate(directionRight);
                if (i >= 1)
                {
                    for (int i2 = 1; i2 < snake.Length; i2++)
                    {
                        tail.GetComponent<Image>().sprite = tails;
                    }
                    yield return new WaitForSeconds(waitingTime);
                    snake[i].GetComponent<Image>().sprite = normal;
                    tail.GetComponent<Image>().sprite = tails;
                }
            }
            rotateRight = false;
        }
    }
}