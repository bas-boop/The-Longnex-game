using UnityEngine;
//using System;
//using System.Collections;
//using System.Linq;
using System.Collections.Generic;

public class DressingRoomButtons : MonoBehaviour
{
    //[SerializeField]private GameObject[] head;
    [SerializeField]private List<GameObject> head = new List<GameObject>();

    private int _index = 0;

    public void NextItem()//Omhoog knop
    {
        _index = _index + 1;
        if (_index == head.Count)
            _index = _index = 0;
        Debug.Log(head[_index]);
    }
    public void PreviousItem()//Omlaag knop
    {
        _index = _index - 1;
        if (_index < 0)
            _index = head.Count - 1;
        Debug.Log(head[_index]);
    }
}
