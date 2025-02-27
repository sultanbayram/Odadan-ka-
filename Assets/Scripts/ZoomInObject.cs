﻿using UnityEngine;

public class ZoomInObject : MonoBehaviour, IInteractable
{
    public float zoomRatio = .5f;
    private float positionX;
    private float positionY;
    private float positionZ;

    void SetUpCameraPosition() 
    {
        positionX = this.transform.position.x;
        positionY = this.transform.position.y;
        positionZ = Camera.main.transform.position.z;
    }

    public void Interact(DisplayImage mevcutDisplay)
    {
        SetUpCameraPosition();
        Camera.main.orthographicSize *= zoomRatio;
        Camera.main.transform.position = new Vector3(positionX, positionY, positionZ);

        //ignore raycast after first zoom
        gameObject.layer = 2;
        
        //change state to zoomed
        mevcutDisplay.SimdikiDurum = DisplayImage.State.Zoomed;

        ConstraintCamera();
    }

    private void ConstraintCamera()
    {
        GameObject.Find("cameraBounds").GetComponent<CameraBounds>().KisitlamayiKontrolEt();

        var zoomedObjects = FindObjectsOfType<ZoomInObject>();
    }
}
