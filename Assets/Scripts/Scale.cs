using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    public GameObject[] scaleBoxes;
    private Block[] blocks;
    private DisplayImage mevcutDisplay;
    public GameObject scaleDisplayer;
    private int[] weight = new int[5] { 1, 2, 4, 8, 3 };
    public bool isSolved { get; private set; } = false;

    private void Awake()
    {
        mevcutDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        blocks = FindObjectsOfType<Block>();
    }

    private void Update()
    {
        Display();

        if (VerifySolution() && !isSolved) 
        {
            isSolved = true;
            scaleDisplayer.GetComponent<ChangeView>().odaAdi = "scale solved";
            mevcutDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/scale solved");
        }
    }

    void Display() 
    {
        for (int i = 0, l = blocks.Length; i < l; i++)
        {
            if (mevcutDisplay.GetComponent<SpriteRenderer>().sprite.name == "scale" || mevcutDisplay.GetComponent<SpriteRenderer>().sprite.name == "scale solved")
            {
                blocks[i].gameObject.SetActive(true);
            }
            else 
            {
                blocks[i].gameObject.SetActive(false);
            }
        }
    }

    bool VerifySolution() 
    {
        bool solved = true;

        for (int i = 0, l = scaleBoxes.Length; i < l; i++)
        {
            if (blocks[i].KutuIndeksi != blocks[i].dogruKutuIndeksi) 
            {
                solved = false;
            }
        }

        return solved;
    }
}

