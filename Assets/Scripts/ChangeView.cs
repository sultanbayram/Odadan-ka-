using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeView : MonoBehaviour, IInteractable
{
    public string odaAdi;

    private float ilkKameraBoyutu;
    private Vector3 ilkKameraPozisyonu;

    private void Start()
    {
        ilkKameraBoyutu = Camera.main.orthographicSize;
        ilkKameraPozisyonu = Camera.main.transform.position;
    }

    public void Interact(DisplayImage mevcutDisplay)
    {
        mevcutDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + odaAdi);
        mevcutDisplay.SimdikiDurum = DisplayImage.State.GorunumuDegis;
        
        Camera.main.orthographicSize = ilkKameraBoyutu;
        Camera.main.transform.position = ilkKameraPozisyonu;
    }
}
