using System;
using UnityEngine;
//using System;
//using System.Collections;
//using System.Linq;
using System.Collections.Generic;
using System.Linq;

public class DressingRoomButtons : MonoBehaviour
{
    [SerializeField]private List<GameObject> head = new List<GameObject>();

    private int _index = 0;
    [SerializeField] private GameObject currentItem;

    private void Start()
    {
        currentItem = head[0];
        currentItem = head[_index];
    }
    
    public void NextItem()//Omhoog knop
    {
        currentItem.SetActive(false);
        _index = _index + 1;
        if (_index == head.Count)
            _index = _index = 0;

        currentItem = head[_index];
        currentItem.SetActive(true);
        
        Debug.Log(head[_index]);
    }
    public void PreviousItem()//Omlaag knop
    {
        currentItem.SetActive(false);
        _index = _index - 1;
        if (_index < 0)
            _index = head.Count - 1;
        
        currentItem = head[_index];
        currentItem.SetActive(true);
        
        Debug.Log(head[_index]);
    }
}
