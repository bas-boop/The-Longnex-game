using System;
using UnityEngine;
using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class HeadDressingRoomButtons : MonoBehaviour
{
    [SerializeField] private List<GameObject> head = new List<GameObject>();
    private int _index = 0;
    [SerializeField] private GameObject currentItem;

    private GameObject _lock;

    private void Start()
    {
        _index = 0;
        currentItem = head[_index];

        _lock = GameObject.Find("LockH");
        _lock.SetActive(false);
    }
    
    public void NextItem()
    {
        currentItem.SetActive(false);
        _index += 1;
        if (_index == head.Count)
            _index = _index = 0;
        
        if (head[_index].CompareTag("lockedItem"))
        {
            _lock.SetActive(true);
        }else
            _lock.SetActive(false);
        
        currentItem = head[_index];
        currentItem.SetActive(true);
    }
    public void PreviousItem()
    {
        currentItem.SetActive(false);
        _index = _index - 1;
        
        if (_index < 0)
            _index = head.Count - 1;
        
        if (head[_index].CompareTag("lockedItem"))
        {
            _lock.SetActive(true);
        }else
            _lock.SetActive(false);

        currentItem = head[_index];
        currentItem.SetActive(true);
    }
}
