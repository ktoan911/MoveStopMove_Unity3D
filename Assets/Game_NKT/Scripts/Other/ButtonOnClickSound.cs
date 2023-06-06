using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonOnClickSound : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        SoundManager.Ins.ButtonClickSound();
    }
}
