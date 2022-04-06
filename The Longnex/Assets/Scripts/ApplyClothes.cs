using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ApplyClothes : MonoBehaviour
{
    private DressingRoom _DR;
    
    public int currentHead;
    public int currentHair;
    public int currentShirt;
    public  int currentAccessorie;
    
    private void Start()
    {
        _DR = GetComponent<DressingRoom>();
    }

    private void Update()
    {
        currentHead = _DR.hatIndex;
        currentHair = _DR.hairIndex;
        currentAccessorie = _DR.AIndex;
        currentShirt = _DR.SIndex;
    }

    public void SaveClothes()
    {
        string json = File.ReadAllText(Application.dataPath + "/Json/ApplyClothes.json");
        Clothes loadedClothes = JsonUtility.FromJson<Clothes>(json);

        loadedClothes.hat = currentHead;
        loadedClothes.hair = currentHair;
        loadedClothes.shirt = currentShirt;
        loadedClothes.accessorie = currentAccessorie;

        string savedClothes = JsonUtility.ToJson(loadedClothes);
        File.WriteAllText(Application.dataPath + "/Json/ApplyClothes.json", savedClothes);
        
        Debug.Log(savedClothes);
    }

    class Clothes
    {
        public int hat;
        public int hair;
        public int accessorie;
        public int shirt;
    }
}
