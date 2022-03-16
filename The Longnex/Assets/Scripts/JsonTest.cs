using System.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonTest : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("GameManger start");
        
        //class en varibales aanmaken in deze class
        GeldBank geldBank = new GeldBank();
        geldBank.geld = 2;
    
        //json file is nu een string
        //raw json debug
        //string json = JsonUtility.ToJson(geldBank);
        //Debug.Log(json);

        //json file opslaan met bestaande json inhoud
        //using System.IO; is nodig hier voor
        //vergeet de / niet voor de naam van de json
        //File.WriteAllText(Application.dataPath + "/Json/kiekeboe.json", json);
        
        //een aangemaakte json zoeken en een string er van maken
        string json = File.ReadAllText(Application.dataPath + "/Json/saveFile.json");
        
        //loaded json netter debuggen
        GeldBank loadedGeldBank = JsonUtility.FromJson<GeldBank>(json);
        Debug.Log("geld: " + loadedGeldBank.geld);
    }
    
    private class GeldBank
    {
        //data die er bestaat
        public float geld;
    }
}
