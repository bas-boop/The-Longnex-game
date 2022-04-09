using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class BackgroundChanger : MonoBehaviour
{
    [SerializeField] private GameObject camera;
    private GameObject _startColor;

    private void Start()
    {
        //_startColor = camera.GetComponent<Background>();
    }
}
