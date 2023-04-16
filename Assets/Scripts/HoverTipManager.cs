using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class HoverTipManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image hoverImage;
    public Image hoverTriggerImage;

    private bool isHovering = false;


    private void Update()
    {
        if (isHovering)
        {
            hoverImage.gameObject.SetActive(true);
        }
        else
        {
            hoverImage.gameObject.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject == hoverTriggerImage.gameObject)
        {
            isHovering = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject != hoverTriggerImage.gameObject)
        {
            isHovering = false;
        }
    }
}