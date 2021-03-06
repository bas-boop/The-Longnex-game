using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ApplyClothes : MonoBehaviour
{
    /// <summary>
    /// als je de gekozen items saved dan schrijft ie dat in de json file ApplyClothes.json
    /// als je een item locked is wordt het 0, wat gelijk staat aan niks (geen kleding)
    /// </summary>
    
    private DressingRoom _DR;
    
    public int currentHead;
    public int currentHair;
    public int currentShirt;
    public int currentAccessorie;

    private void Start()
    {
        _DR = GetComponent<DressingRoom>();
    }

    public void SaveClothes()
    {
        currentHead = _DR.hatIndex;
        currentHair = _DR.hairIndex;
        currentAccessorie = _DR.AIndex;
        currentShirt = _DR.SIndex;
        
        if (_DR.headLokced)
            currentHead = 0;
        if (_DR.hairLocked)
            currentHair = 0;
        if (_DR.ALokced)
            currentAccessorie = 0;
        if (_DR.SLocked)
            currentShirt = 0;
        
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
