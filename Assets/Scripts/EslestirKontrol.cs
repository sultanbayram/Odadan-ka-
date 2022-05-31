using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EslestirKontrol : MonoBehaviour
{
    [SerializeField]
    private GameObject winText;
    void Start()
    {
        winText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Ayi.locked && Fil.locked && Path.locked)
            winText.SetActive(true);
    }
}