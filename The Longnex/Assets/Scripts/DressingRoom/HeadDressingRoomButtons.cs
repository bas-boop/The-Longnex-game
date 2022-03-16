using System;
using UnityEngine;
//using System;
//using System.Collections;
//using System.Linq;
using System.Collections.Generic;

public class HeadDressingRoomButtons : MonoBehaviour
{
    [SerializeField] private List<GameObject> head = new List<GameObject>();
    private int _index = 0;
    [SerializeField] private GameObject currentItem;
    [SerializeField] private GameObject nextItem;
    //[SerializeField] private GameObject previousItem;

    private void Start()
    {
        currentItem = head[_index];
        nextItem = head[_index + 1];
        //previousItem = head[_index - 1];
    }
    
    public void NextItem()
    {
        currentItem.SetActive(false);
        _index = _index + 1;
        if (currentItem.CompareTag("lockedItem"))
        {
            currentItem.SetActive(false);
            _index =+ 1;
        }
        if (_index == head.Count)
            _index = _index = 0;
        
        currentItem = head[_index];
        currentItem.SetActive(true);
        
        Debug.Log(head[_index]);
    }
    public void PreviousItem()
    {
        currentItem.SetActive(false);
        _index = _index - 1;
        if (currentItem.CompareTag("lockedItem"))
        {
            currentItem.SetActive(false);
            _index =- 1;
        }
        if (_index < 0)
            _index = head.Count - 1;
        
        currentItem = head[_index];
        currentItem.SetActive(true);
        
        Debug.Log(head[_index]);
    }
}
