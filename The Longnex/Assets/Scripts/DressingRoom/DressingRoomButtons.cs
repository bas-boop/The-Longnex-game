using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DressingRoomButtons : MonoBehaviour
{
    //[SerializeField]private GameObject[] head;
    [SerializeField]private List<GameObject> head = new List<GameObject>();

    public void NextItem()
    {
        for (int i = 0; i < head.Count; i++)
        {
            Debug.Log(head[i]);
        }
    }
    public void PreviousItem()
    {
        for (int i = 0; i < head.Count; i--)
        {
            Debug.Log(head[i]);
        }
    }
}
