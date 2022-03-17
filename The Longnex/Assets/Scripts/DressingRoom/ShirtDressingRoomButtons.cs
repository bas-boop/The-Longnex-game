using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShirtDressingRoomButtons : MonoBehaviour
{
    [SerializeField]private List<GameObject> shirts = new List<GameObject>();

    private int _index = 0;
    [SerializeField] private GameObject currentItem;

    private void Start()
    {
        currentItem = shirts[0];
        currentItem = shirts[_index];
    }
    
    public void NextItem()//Omhoog knop
    {
        currentItem.SetActive(false);
        _index += 1;
        if (_index == shirts.Count)
            _index = _index = 0;

        currentItem = shirts[_index];
        currentItem.SetActive(true);
        
        Debug.Log(shirts[_index]);
    }
    public void PreviousItem()//Omlaag knop
    {
        currentItem.SetActive(false);
        _index = _index - 1;
        if (_index < 0)
            _index = shirts.Count - 1;
        
        currentItem = shirts[_index];
        currentItem.SetActive(true);
        
        Debug.Log(shirts[_index]);
    }
}
