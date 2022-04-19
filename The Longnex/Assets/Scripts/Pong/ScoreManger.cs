using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManger : MonoBehaviour
{
    public Blokje blokje;
    
    private int _P1Score;
    private int _P2Score;

    public void Player1Scores()
    {
        _P1Score++;
        Debug.Log("P1 scored");
        this.blokje.RespawnBlokje();
    }
    public void Player2Scores()
    {
        _P2Score++;
        Debug.Log("P2 scored");
        this.blokje.RespawnBlokje();
    }
}
