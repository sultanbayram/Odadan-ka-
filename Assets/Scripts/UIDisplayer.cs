using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDisplayer : MonoBehaviour, IInteractable
{
    public GameObject displayObject;

    public void Interact(DisplayImage mevcutDisplay)
    {
        displayObject.SetActive(true);
    }
}
