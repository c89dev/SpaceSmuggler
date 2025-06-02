using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ViewInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private float visibleAlpha = 1f;
    private float hiddenAlpha = 0f;
    public Button button;
    public TextMeshProUGUI textMeshProUGUI;

    void OnEnable()
    {
        SetTextAlpha(hiddenAlpha);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (textMeshProUGUI != null)
        {
            // Set the alpha to 1 (fully visible) on hover
            SetTextAlpha(visibleAlpha);
            Debug.Log("Hovering");
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (textMeshProUGUI != null)
        {
            // Set the alpha to 1 (fully visible) on hover
            SetTextAlpha(hiddenAlpha);
            Debug.Log("Hovering");
        }
    }

        private void SetTextAlpha(float alpha)
    {
        Color textColor = textMeshProUGUI.color;
        textColor.a = alpha; // Set the alpha value (0-1 range)
        textMeshProUGUI.color = textColor; // Apply the new color
    }
}
