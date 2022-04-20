using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    /// <summary>
    /// Start game button script
    /// </summary>
    
    [SerializeField] private Blokje blokje;
    [SerializeField] private GameObject knopje;

    public void StartGameButton()
    {
        knopje.SetActive(false);
        blokje.RespawnBlokje();
    }
}
