using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HoverManager : MonoBehaviour
{
   

    private void OnMouseEnter()
    {
        increaseScale(true);
    }

    private void OnMouseExit()
    {
        increaseScale(false);
    }

    private Vector3 initialScale;
    private void Awake()
    {
        initialScale = transform.localScale;
    }

    [SerializeField] private float popupScale = 1.5f;
    [SerializeField] private float popupLength = 0.15f;

    private void increaseScale(bool Status)
    {
        Vector3 finalScale = initialScale;

        if (Status)
        {
            finalScale = initialScale * popupScale;
            transform.DOScale(finalScale, popupLength);
        }
        else if (!Status) 
        { 
            finalScale=initialScale;
            transform.DOScale(finalScale, popupLength);
        }
    }
}
