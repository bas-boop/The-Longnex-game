using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ApplyClothes : MonoBehaviour
{
    /*private HeadDressingRoomButtons Head;
    private ShirtDressingRoomButtons Shirt;
    private AccessoriesDressingRoomButtons Accessories;*/
    
    public int currentHead;
    public int currentShirt;
    public  int currentAccessorie;
    
    private void Start()
    {
        /*Head = GetComponent<HeadDressingRoomButtons>();
        Shirt = GetComponent<ShirtDressingRoomButtons>();
        Accessories = GetComponent<AccessoriesDressingRoomButtons>();*/
    }

    private void Update()
    {
        /*currentHead = Head.index;
        currentAccessorie = Accessories.index;
        currentShirt = Shirt.index;*/
    }

    public void SaveClothes()
    {
        string json = File.ReadAllText(Application.dataPath + "/Json/ApplyClothes.json");
        Clothes loadedClothes = JsonUtility.FromJson<Clothes>(json);

        loadedClothes.hat = currentHead;
        loadedClothes.shirt = currentShirt;
        loadedClothes.accessorie = currentAccessorie;

        /*Debug.Log(loadedClothes.hat);
        Debug.Log(loadedClothes.accessorie);
        Debug.Log(loadedClothes.shirt);*/

        string savedClothes = JsonUtility.ToJson(loadedClothes);
        File.WriteAllText(Application.dataPath + "/Json/ApplyClothes.json", savedClothes);
        
        Debug.Log(savedClothes);
    }

    class Clothes
    {
        public int hat;
        public int accessorie;
        public int shirt;
    }
}
