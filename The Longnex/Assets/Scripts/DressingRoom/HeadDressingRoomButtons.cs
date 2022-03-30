using System;
using System.IO;
using UnityEngine;
using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class HeadDressingRoomButtons : MonoBehaviour
{
    [SerializeField] private List<GameObject> head/* = new List<GameObject>()*/;
    public int index = 0;
    [SerializeField]private GameObject currentItem;

    private GameObject _lock;

    private void Start()
    {
        index = 0;
        currentItem = head[index];

        _lock = GameObject.Find("LockH");
        _lock.SetActive(false);

        itemTagging();
    }
    
    public void NextItem()
    {
        currentItem.SetActive(false);
        index += 1;
        if (index == head.Count)
            index = index = 0;
        
        if (head[index].CompareTag("lockedItem"))
        {
            _lock.SetActive(true);
        }else
            _lock.SetActive(false);
        
        currentItem = head[index];
        currentItem.SetActive(true);
    }
    public void PreviousItem()
    {
        currentItem.SetActive(false);
        index = index - 1;
        
        if (index < 0)
            index = head.Count - 1;
        
        if (head[index].CompareTag("lockedItem"))
        {
            _lock.SetActive(true);
        }else
            _lock.SetActive(false);

        currentItem = head[index];
        currentItem.SetActive(true);
    }

    private void itemTagging()
    {
        string json = File.ReadAllText(Application.dataPath + "/Json/LockedItems/lockedItems.json");
        //Debug.Log(json);

        LockedItem loadedhead = JsonUtility.FromJson<LockedItem>(json);

        for (int i = 0; i < head.Count; i++)
        {
            if(loadedhead.hats[i])
            {
                head[i].tag = "lockedItem";
            }else if (!loadedhead.hats[i])
            {
                head[i].tag = "unlockedItem";
            }
        }
    }

    public class LockedItem
    {
        public bool[] hats;
    }
}