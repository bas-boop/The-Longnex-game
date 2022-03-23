using System;
using System.IO;
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

        itemTagging();
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

    private void itemTagging()
    {
        string json = File.ReadAllText(Application.dataPath + "/Json/LockedItems/lockedItems.json");
        //Debug.Log(json);

        LockedItem loadedhead = JsonUtility.FromJson<LockedItem>(json);
        Debug.Log(loadedhead);

        for (int i = 0; i < head.Count; i++)
        {
            if(loadedhead.hats[i])
            {
                head[i].tag = "lockedItem";
            }else if (loadedhead.hats[i])
            {
                head[i].tag = "lockedItem";
            }
        }
        /*if (!loadedhead.hat1)
        {
            head[1].tag = "unlockedItem";
        }else if (loadedhead.hats1)
        {
            head[1].tag = "lockedItem";
        }*/
    }

    class LockedItem
    {
        public List<bool> hats;
        //public bool hat0, hat1, hat2, hat3, hat4,hat5, hat6, hat7, hat8, hat9, hat10, hat11, hat12, hat13, hat14, hat15, hat16;
    }
}
