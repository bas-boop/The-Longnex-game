using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ShirtDressingRoomButtons : MonoBehaviour
{
    [SerializeField]private List<GameObject> shirts = new List<GameObject>();

    private int _index = 0;
    [SerializeField] private GameObject currentItem;
    
    private GameObject _lock;

    private void Start()
    {
        currentItem = shirts[0];
        currentItem = shirts[_index];
        
        _lock = GameObject.Find("LockS");
        _lock.SetActive(false);
        
        itemTagging();
    }
    
    public void NextItem()//Omhoog knop
    {
        currentItem.SetActive(false);
        _index += 1;
        if (_index == shirts.Count)
            _index = _index = 0;

        if (shirts[_index].CompareTag("lockedItem"))
        {
            _lock.SetActive(true);
        }else
            _lock.SetActive(false);
        
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
        
        if (shirts[_index].CompareTag("lockedItem"))
        {
            _lock.SetActive(true);
        }else
            _lock.SetActive(false);
        
        currentItem = shirts[_index];
        currentItem.SetActive(true);
    }
    private void itemTagging()
    {
        string json = File.ReadAllText(Application.dataPath + "/Json/LockedItems/lockedItems.json");
        //Debug.Log(json);

        LockedItem loadedhead = JsonUtility.FromJson<LockedItem>(json);
        Debug.Log(loadedhead);

        for (int i = 0; i < shirts.Count; i++)
        {
            if(loadedhead.shirtz[i])
            {
                shirts[i].tag = "lockedItem";
            }else if (!loadedhead.shirtz[i])
            {
                shirts[i].tag = "unlockedItem";
            }
        }
    }
    public class LockedItem
    {
        public bool[] shirtz;
    }
}
