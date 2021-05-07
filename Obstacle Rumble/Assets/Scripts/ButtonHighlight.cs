using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonHighlight : MonoBehaviour,  IPointerEnterHandler
{
    [SerializeField] private AudioSource highlight;
    public void OnPointerEnter(PointerEventData eventData)
    {
        highlight.Play();
    }
}


