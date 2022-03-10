using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AccessoriesDressingRoomButtons : MonoBehaviour
{
    [SerializeField]private List<GameObject> accessories = new List<GameObject>();

    private int _index = 0;
    [SerializeField] private GameObject currentItem;

    private void Start()
    {
        currentItem = accessories[0];
        currentItem = accessories[_index];
    }
    
    public void NextItem()//Omhoog knop
    {
        currentItem.SetActive(false);
        _index = _index + 1;
        if (_index == accessories.Count)
            _index = _index = 0;

        currentItem = accessories[_index];
        currentItem.SetActive(true);
        
        Debug.Log(accessories[_index]);
    }
    public void PreviousItem()//Omlaag knop
    {
        currentItem.SetActive(false);
        _index = _index - 1;
        if (_index < 0)
            _index = accessories.Count - 1;
        
        currentItem = accessories[_index];
        currentItem.SetActive(true);
        
        Debug.Log(accessories[_index]);
    }
}
