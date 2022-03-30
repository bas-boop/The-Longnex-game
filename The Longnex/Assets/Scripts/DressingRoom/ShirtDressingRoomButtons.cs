using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ShirtDressingRoomButtons : MonoBehaviour
{
    [SerializeField]private List<GameObject> shirts = new List<GameObject>();

    public int index = 0;
    [SerializeField] private GameObject currentItem;
    
    private GameObject _lock;

    private void Start()
    {
        currentItem = shirts[0];
        currentItem = shirts[index];
        
        _lock = GameObject.Find("LockS");
        _lock.SetActive(false);
        
        itemTagging();
    }
    
    public void NextItem()//Omhoog knop
    {
        currentItem.SetActive(false);
        index += 1;
        if (index == shirts.Count)
            index = index = 0;

        if (shirts[index].CompareTag("lockedItem"))
        {
            _lock.SetActive(true);
        }else
            _lock.SetActive(false);
        
        currentItem = shirts[index];
        currentItem.SetActive(true);
    }
    public void PreviousItem()//Omlaag knop
    {
        currentItem.SetActive(false);
        index = index - 1;
        if (index < 0)
            index = shirts.Count - 1;
        
        if (shirts[index].CompareTag("lockedItem"))
        {
            _lock.SetActive(true);
        }else
            _lock.SetActive(false);
        
        currentItem = shirts[index];
        currentItem.SetActive(true);
    }
    private void itemTagging()
    {
        string json = File.ReadAllText(Application.dataPath + "/Json/LockedItems/lockedItems.json");
        //Debug.Log(json);

        LockedItem loadedhead = JsonUtility.FromJson<LockedItem>(json);

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
