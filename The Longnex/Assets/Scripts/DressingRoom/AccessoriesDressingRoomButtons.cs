using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AccessoriesDressingRoomButtons : MonoBehaviour
{
    [SerializeField]private List<GameObject> accessories = new List<GameObject>();

    private int _index = 0;
    [SerializeField] private GameObject currentItem;
    
    private GameObject _lock;

    private void Start()
    {
        currentItem = accessories[0];
        currentItem = accessories[_index];
        
        _lock = GameObject.Find("LockA");
        _lock.SetActive(false);
    }
    
    public void NextItem()//Omhoog knop
    {
        currentItem.SetActive(false);
        _index = _index + 1;
        if (_index == accessories.Count)
            _index = _index = 0;

        if (accessories[_index].CompareTag("lockedItem"))
        {
            _lock.SetActive(true);
            //currentItem.GetComponent<Color>() = new Color(0, 0, 0, 150); //wou de item zelf ook transpierant maken
        }else
        {
            _lock.SetActive(false);   
        }

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
        
        if (accessories[_index].CompareTag("lockedItem"))
        {
            _lock.SetActive(true);
        }else
            _lock.SetActive(false);
        
        currentItem = accessories[_index];
        currentItem.SetActive(true);
        
        Debug.Log(accessories[_index]);
    }
}
