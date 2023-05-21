using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    AudioScript audioScript;
    Image image;
    private Color originalColor;
    private Color darkerColor;

    void Awake()
    {
        image = GetComponent<Image>();
        originalColor = image.color;
        darkerColor = originalColor * 0.8f;
    }

    void Start()
    {
        audioScript = GameObject.Find("AudioObject").GetComponent<AudioScript>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        audioScript.PlaySelectSFX();
        image.color = darkerColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = originalColor;
    }
}
