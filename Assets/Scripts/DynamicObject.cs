﻿using UnityEngine;
using UnityEngine.UI;

public class DynamicObject : MonoBehaviour, IInteractable
{
    public enum InteractionProperty { SimpleInteraction, AccessInteraction}
    public InteractionProperty Property;

    public string UnlockItem;
    public GameObject AccessObject;

    public GameObject ChangeStateSprite;
    private GameObject inventory;

    public void Interact(DisplayImage mevcutDisplay)
    {
        if (inventory.GetComponent<Inventory>().CurrentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem || UnlockItem == "")
        {
            ChangeStateSprite.SetActive(true);
            gameObject.layer = 2;

            if (Property == InteractionProperty.SimpleInteraction) return;

            AccessObject.SetActive(true);
            inventory.GetComponent<Inventory>().CurrentSelectedSlot.GetComponent<Slot>().ClearSlot();
        }
    }

    private void Start()
    {
        ChangeStateSprite.SetActive(false);
        inventory = GameObject.Find("Inventory");
        if (Property == InteractionProperty.SimpleInteraction) return;
        AccessObject.SetActive(false);
    }
}
