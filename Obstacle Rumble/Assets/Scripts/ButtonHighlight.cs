using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHighlight : MonoBehaviour,  IPointerEnterHandler
{
    [SerializeField] private AudioSource highlight;
    public void OnPointerEnter(PointerEventData eventData)
    {
        highlight.Play();
    }
}


