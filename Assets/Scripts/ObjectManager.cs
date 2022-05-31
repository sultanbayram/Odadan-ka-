using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    DisplayImage mevcutDisplay;
    public GameObject[] YonetilecekNesne;
    public GameObject[] UIRendererObjects;

    // Start is called before the first frame update
    void Start()
    {
        mevcutDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        RenderUI();
    }

    // Update is called once per frame
    void Update()
    {
        NesneyiYonet();
    }

    void NesneyiYonet() 
    {
        for (int i = 0, l = YonetilecekNesne.Length; i < l; i++)
        {
            if (YonetilecekNesne[i].name == mevcutDisplay.GetComponent<SpriteRenderer>().sprite.name)
            {
                YonetilecekNesne[i].SetActive(true);
            }
            else 
            {
                YonetilecekNesne[i].SetActive(false);
            }
        }
    }

    void RenderUI()
    {
        for (int i = 0, l = UIRendererObjects.Length; i < l; i++)
        {
            UIRendererObjects[i].SetActive(false);
        }
    }
}
