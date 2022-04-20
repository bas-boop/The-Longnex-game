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
    /// en misschien user colorcode input
    /// of misschien de image ook
    /// </summary>
    
    [SerializeField] private GameObject background;

    [Header("COLOR'S")]
    //[SerializeField] private Color[] colors;
    [SerializeField] private List<Color> colors;
    [SerializeField] private Color currentColor;
    [SerializeField] private Color startColor;

    [Header("IMAGE'S")]
    [SerializeField] private Sprite startImage;
    [SerializeField] private Sprite currentImage;

    private int _index;
    
    private void Start()
    {
        _index = 0;
        currentColor = colors[_index];
        
        startColor = background.GetComponent<SpriteRenderer>().color;
        currentColor = startColor;

        startImage = background.GetComponent<SpriteRenderer>().sprite;
        currentImage = startImage;
    }

    public void Knopje()
    {
        if (_index + 1 == colors.Count)
            _index = -1;
        
        _index += 1;
        currentColor = colors[_index];

        background.GetComponent<SpriteRenderer>().color = currentColor;
    }
}
