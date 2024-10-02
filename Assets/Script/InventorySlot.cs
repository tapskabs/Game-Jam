using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon; // The UI icon for the item
    public Image highlightImage; // An image to show when the slot is highlighted

    // Function to set the item in the UI slot
    public void SetItem(Sprite itemIcon)
    {
        icon.sprite = itemIcon;
        icon.enabled = true; // Show the item in the UI
    }

    // Function to clear the slot
    public void ClearSlot()
    {
        icon.sprite = null;
        icon.enabled = false; // Hide the item in the UI
    }

    // Highlight the slot to show it's selected
    public void Highlight(bool isHighlighted)
    {
        highlightImage.enabled = isHighlighted; // Show or hide the highlight image
    }
}

