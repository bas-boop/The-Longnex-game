using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManger : MonoBehaviour
{
    /// <summary>
    /// Dit zorged voor de UI score
    /// </summary>
    
    public Blokje blokje;
    
    private int _P1Score;
    private int _P2Score;

    [SerializeField] private TMP_Text P1Score;
    [SerializeField] private TMP_Text P2Score;

    [SerializeField] private GameObject P1WScreen;
    [SerializeField] private GameObject P2WScreen;

    private void Awake()
    {
        P1WScreen.SetActive(false);
        P2WScreen.SetActive(false);
    }

    private void Update()
    {
        if (_P1Score == 9)
        {
            Debug.Log("Player 1 won");
            Player1Won();
        }
        else if (_P2Score == 9)
        {
            Debug.Log("Player 2 won");
            Player2Won();
        }
    }

    public void Player1Scores()
    {
        _P1Score++;
        Debug.Log("P1 scored");

        this.P1Score.text = _P1Score.ToString();
        
        this.blokje.RespawnBlokje();
    }
    public void Player2Scores()
    {
        _P2Score++;
        Debug.Log("P2 scored");
        
        this.P2Score.text = _P2Score.ToString();
        
        this.blokje.RespawnBlokje();
    }

    private void Player1Won()
    {
        Destroy(blokje.gameObject);
        P1WScreen.SetActive(true);
    }
    private void Player2Won()
    {
        Destroy(blokje.gameObject);
        P2WScreen.SetActive(true);
    }
}
