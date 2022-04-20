using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class ScoringZone : MonoBehaviour
{
    /// <summary>
    /// Dit moet op een collider van de muur
    /// Hier in kan je een functie aan roepen van een andere script
    /// </summary>
    
    public EventTrigger.TriggerEvent scoreTrigger;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Blokje blokje = collision.gameObject.GetComponent<Blokje>();

        if (blokje != null)
        {
            BaseEventData eventData = new BaseEventData(EventSystem.current);
            this.scoreTrigger.Invoke(eventData);
        }
    }
}
