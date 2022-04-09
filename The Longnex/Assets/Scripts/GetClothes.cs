using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GetClothes : MonoBehaviour
{
    [Header("LISTS")]
    [SerializeField] private List<GameObject> hats;
    [SerializeField] private List<GameObject> hairs;
    [SerializeField] private List<GameObject> accessories;
    [SerializeField] private List<GameObject> shirts;
    
    [Header("Index's")]
    [SerializeField] private int hairIndex;
    [SerializeField] private int hatIndex;
    [SerializeField] private int AIndex;
    [SerializeField] private int SIndex;
    
    [Header("CURRENT ITEM'S")]
    [SerializeField] private GameObject currentHat;
    [SerializeField] private GameObject currentHair;
    [SerializeField] private GameObject currentAccessorie;
    [SerializeField] private GameObject currentShirt;


    private void Start()
    {
        string json = File.ReadAllText(Application.dataPath + "/Json/ApplyClothes.json");
        Clothez loadedClothes = JsonUtility.FromJson<Clothez>(json);

        hatIndex = loadedClothes.hat;
        hairIndex = loadedClothes.hair;
        SIndex = loadedClothes.shirt;
        AIndex = loadedClothes.accessorie;
        
        currentHat = hats[hatIndex];
        currentHair = hairs[hairIndex];
        currentAccessorie = accessories[AIndex];
        currentShirt = shirts[SIndex];

        currentHat.SetActive(true);
        currentHair.SetActive(true);
        currentAccessorie.SetActive(true);
        currentShirt.SetActive(true);
    }

    class Clothez
    {
        public int hat;
        public int hair;
        public int accessorie;
        public int shirt;
    }
}
