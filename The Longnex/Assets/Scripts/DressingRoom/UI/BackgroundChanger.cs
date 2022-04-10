using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class BackgroundChanger : MonoBehaviour
{
    /// <summary>
    /// Hier kan je de kleur veranderen van de background
    /// en misschien de image ook
    /// </summary>
    
    [SerializeField] private GameObject background;
    
    [Header("COLOR'S")]
    [SerializeField] private Color currentColor;
    [SerializeField] private Color startColor;

    [Header("IMAGE'S")]
    [SerializeField] private Sprite startImage;
    [SerializeField] private Sprite currentImage;
    
    private void Start()
    {
        startColor = background.GetComponent<SpriteRenderer>().color;
        currentColor = startColor;

        startImage = background.GetComponent<SpriteRenderer>().sprite;
        currentImage = startImage;
    }
}
