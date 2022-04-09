using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DressingRoom : MonoBehaviour
{
    [Header("LISTS")]
    [SerializeField] private List<GameObject> hats;
    [SerializeField] private List<GameObject> hairs;
    [SerializeField] private List<GameObject> accessories;
    [SerializeField] private List<GameObject> shirts;
    
    [Header("Index's")]
    public int hairIndex = 0;
    public int hatIndex = 0;
    public int AIndex = 0;
    public int SIndex = 0;
    
    [Header("CURRENT ITEM'S")]
    [SerializeField] private GameObject currentHat;
    [SerializeField] private GameObject currentHair;
    [SerializeField] private GameObject currentAccessorie;
    [SerializeField] private GameObject currentShirt;

    [Header("LOCK BOOL")]
    public bool headLokced;
    public bool hairLocked;
    public bool ALokced;
    public bool SLocked;

    [Header("LOCK'S")] 
    private GameObject _hatLock;
    private GameObject _hairLock;
    private GameObject _ALock;
    private GameObject _SLock;

    private void Start()
    {
        hatIndex = 0;
        hairIndex = 0;
        AIndex = 0;
        SIndex = 0;
        
        currentHat = hats[hatIndex];
        currentHair = hairs[hairIndex];
        currentAccessorie = accessories[AIndex];
        currentShirt = shirts[SIndex];
        
        _hatLock = GameObject.Find("LockHat");
        _hatLock.SetActive(false);
        _hairLock = GameObject.Find("LockHair");
        _hairLock.SetActive(false);
        _ALock = GameObject.Find("LockA");
        _ALock.SetActive(false);
        _SLock = GameObject.Find("LockS");
        _SLock.SetActive(false);
        
        ItemTagging();
    }

    public void NextHat()
    {
        currentHat.SetActive(false);
        hatIndex += 1;
        if (hatIndex == hats.Count)
            hatIndex = 0;
        
        if (hats[hatIndex].CompareTag("lockedItem"))
        {
            _hatLock.SetActive(true);
        }else
            _hatLock.SetActive(false);
        
        currentHat = hats[hatIndex];
        currentHat.SetActive(true);

        if (currentHat.CompareTag("lockedItem"))
        {
            headLokced = true;
        }else
            headLokced = false;
    }

    public void NextHair()
    {
        currentHair.SetActive(false);
        hairIndex += 1;
        if (hairIndex == hairs.Count)
            hairIndex = 0;
        
        if (hairs[hairIndex].CompareTag("lockedItem"))
        {
            _hairLock.SetActive(true);
        }else
            _hairLock.SetActive(false);
        
        currentHair = hairs[hairIndex];
        currentHair.SetActive(true);

        if (currentHair.CompareTag("lockedItem"))
        {
            hairLocked = true;
        }
        else
            hairLocked = false;
    }

    public void NextAccessorie()
    {
        currentAccessorie.SetActive(false);
        AIndex += 1;
        if (AIndex == accessories.Count)
            AIndex = 0;
        
        if (accessories[AIndex].CompareTag("lockedItem"))
        {
            _ALock.SetActive(true);
        }else
            _ALock.SetActive(false);
        
        currentAccessorie = accessories[AIndex];
        currentAccessorie.SetActive(true);
        
        if (currentAccessorie.CompareTag("lockedItem"))
        {
            ALokced = true;
        }else
            ALokced = false;
    }

    public void NextShirt()
    {
        currentShirt.SetActive(false);
        SIndex += 1;
        if (SIndex == shirts.Count)
            SIndex = 0;
        
        if (shirts[SIndex].CompareTag("lockedItem"))
        {
            _SLock.SetActive(true);
        }else
            _SLock.SetActive(false);
        
        currentShirt = shirts[SIndex];
        currentShirt.SetActive(true);
        
        if (currentShirt.CompareTag("lockedItem"))
        {
            SLocked = true;
        }else
            SLocked = false;
    }

    public void PreviousHat()
    {
        currentHat.SetActive(false);
        hatIndex -= 1;
        
        if (hatIndex < 0)
            hatIndex = hats.Count - 1;
        
        if (hats[hatIndex].CompareTag("lockedItem"))
        {
            _hatLock.SetActive(true);
        }else
            _hatLock.SetActive(false);

        currentHat = hats[hatIndex];
        currentHat.SetActive(true);
        
        if (currentHat.CompareTag("lockedItem"))
        {
            headLokced = true;
        }else
            headLokced = false;
    }

    public void PreviousHair()
    {
        currentHair.SetActive(false);
        hairIndex -= 1;
        
        if (hairIndex < 0)
            hairIndex = hairs.Count - 1;
        
        if (hairs[hairIndex].CompareTag("lockedItem"))
        {
            _hairLock.SetActive(true);
        }else
            _hairLock.SetActive(false);

        currentHair = hairs[hairIndex];
        currentHair.SetActive(true);
        
        if (currentHair.CompareTag("lockedItem"))
        {
            hairLocked = true;
        }else
            hairLocked = false;
    }

    public void PreviousAccessorie()
    {
        currentAccessorie.SetActive(false);
        AIndex -= 1;
        
        if (AIndex < 0)
            AIndex = accessories.Count - 1;
        
        if (accessories[AIndex].CompareTag("lockedItem"))
        {
            _ALock.SetActive(true);
        }else
            _ALock.SetActive(false);

        currentAccessorie = accessories[AIndex];
        currentAccessorie.SetActive(true);
        
        if (currentAccessorie.CompareTag("lockedItem"))
        {
            ALokced = true;
        }else
            ALokced = false;
    }

    public void PreviousShirt()
    {
        currentShirt.SetActive(false);
        SIndex -= 1;
        
        if (SIndex < 0)
            SIndex = shirts.Count - 1;
        
        if (shirts[SIndex].CompareTag("lockedItem"))
        {
            _SLock.SetActive(true);
        }else
            _SLock.SetActive(false);

        currentShirt = shirts[SIndex];
        currentShirt.SetActive(true);
        
        if (currentShirt.CompareTag("lockedItem"))
        {
            SLocked = true;
        }else
            SLocked = false;
    }
    
    private void ItemTagging()
    {
        string json = File.ReadAllText(Application.dataPath + "/Json/LockedItems/lockedItems.json");
        //Debug.Log(json);

        LockedItem loadedhead = JsonUtility.FromJson<LockedItem>(json);

        for (int i = 0; i < hats.Count; i++)
        {
            if(loadedhead.hatz[i])
            {
                hats[i].tag = "lockedItem";
            }else if (!loadedhead.hatz[i])
            {
                hats[i].tag = "unlockedItem";
            }
        }
        for (int i = 0; i < hairs.Count; i++)
        {
            if(loadedhead.hairz[i])
            {
                hairs[i].tag = "lockedItem";
            }else if (!loadedhead.hairz[i])
            {
                hats[i].tag = "unlockedItem";
            }
        }
        for (int i = 0; i < accessories.Count; i++)
        {
            if(loadedhead.accessoriez[i])
            {
                accessories[i].tag = "lockedItem";
            }else if (!loadedhead.accessoriez[i])
            {
                accessories[i].tag = "unlockedItem";
            }
        }
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
        public bool[] hatz;
        public bool[] hairz;
        public bool[] accessoriez;
        public bool[] shirtz;
    }
}