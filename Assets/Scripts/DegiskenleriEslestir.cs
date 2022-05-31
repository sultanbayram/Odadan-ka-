using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DegiskenleriEslestir : MonoBehaviour
{
    public bool Tamamlandi { get; private set; } = false;
    private DisplayImage currentDisplay;
    public GameObject claimItem;
    private bool itemSpawn;
    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
    }
    private void Update()
    {
        if (!itemSpawn)
        {
            Object claimItemClone = Instantiate(claimItem, GameObject.Find("WinText").transform, false);
            claimItem.transform.localScale = new Vector3(35, 35, 35);
            itemSpawn = true;
        }

        EkraniGizle();
    }
    public void EkraniGizle()
    {
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            this.gameObject.SetActive(false);
        }
        if (currentDisplay.SimdikiDurum == DisplayImage.State.Normal)
        {
            this.gameObject.SetActive(false);
        }
    }
}