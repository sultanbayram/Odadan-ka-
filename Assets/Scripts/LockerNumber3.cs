﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerNumber3 : MonoBehaviour, IInteractable
{
    public void Interact(DisplayImage mevcutDisplay)
    {
        transform.parent.GetComponent<NumberLock3>().currentIndividualIndex[transform.GetSiblingIndex()]++;

        if (transform.parent.GetComponent<NumberLock3>().currentIndividualIndex[transform.GetSiblingIndex()] > 4)

            transform.parent.GetComponent<NumberLock3>().currentIndividualIndex[transform.GetSiblingIndex()] = 0;


        this.gameObject.GetComponent<SpriteRenderer>().sprite =
             transform.parent.GetComponent<NumberLock3>().numberSprites[transform.parent.GetComponent<NumberLock3>().currentIndividualIndex[transform.GetSiblingIndex()]];
    }
}
