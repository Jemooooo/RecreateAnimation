using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CardFlip : MonoBehaviour
{
    private SpriteRenderer render;
    [SerializeField] private Sprite faceDown, faceUp;

    private bool coRoutAllowed, facedUp;

    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        render.sprite = faceDown;
        coRoutAllowed = true;
        facedUp = false;
    }

    private void OnMouseDown()
    {
        if (coRoutAllowed)
        {
            StartCoroutine(RotateCard());
        }
    }

    private IEnumerator RotateCard()
    {
        coRoutAllowed = false;

        if (!facedUp)
        {
            // Flip to faceUp slowly
            for (float i = 0f; i <= 180f; i += 5f)  // Smaller step for smoother flip
            {
                transform.rotation = Quaternion.Euler(0f, i, 0f);
                if (i == 90f)
                {
                    render.sprite = faceUp;
                }
                yield return new WaitForSeconds(0.02f);  // Increase wait time for a slower flip
            }
            // Shake rotation when flipped to faceUp
            transform.DOShakeRotation(0.5f, 10f, 10, 90);
        }
        else
        {
            // Flip back to faceDown slowly
            for (float i = 180f; i >= 0f; i -= 5f)  // Smaller step for smoother flip
            {
                transform.rotation = Quaternion.Euler(0f, i, 0f);
                if (i == 90f)
                {
                    render.sprite = faceDown;
                }
                yield return new WaitForSeconds(0.02f);  // Increase wait time for a slower flip
            }
            // Shake rotation when flipped back to faceDown
            transform.DOShakeRotation(0.5f, 10f, 10, 90);
        }

        coRoutAllowed = true;
        facedUp = !facedUp;
    }
}
