﻿using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour, IInteractable
{
    public string displaySprite;
    public string displayImage;
    private GameObject inventorySlots;

    public enum Property { Usable, Displayable }
    public Property itemProperty;

    public string combinationItem;

    public void Interact(DisplayImage mevcutDisplay)
    {
        ItemPickUp();
    }

    private void Start()
    {
        
    }

    public void ItemPickUp() 
    {
        inventorySlots = GameObject.Find("Slots");
        
        foreach (Transform slot in inventorySlots.transform) 
        {
            if (slot.GetChild(0).GetComponent<Image>().sprite.name == "empty_item") 
            {
                slot.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("InventoryItems/" + displaySprite);
                slot.GetComponent<Slot>().AssignProperty((int) itemProperty, displayImage, combinationItem);
                Destroy(gameObject);
                break;
            }
        }
    }
}
