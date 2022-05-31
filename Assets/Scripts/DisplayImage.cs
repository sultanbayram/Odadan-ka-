using UnityEngine;
using System.Collections.Generic;

public class DisplayImage : MonoBehaviour
{
    private int simdikiOda;
    private int oncekiOda;

    public enum State 
    {
        Normal,
        Zoomed,
        GorunumuDegis
    }

    public State SimdikiDurum { get; set; }

    public int MevcutOda 
    {
        get 
        {
            return simdikiOda;
        }
        set
        {
            if (value == 5)
            {
                simdikiOda = 1;
            }
            else if (value == 0)
            {
                simdikiOda = 4;
            }
            else
            {
                simdikiOda = value;
            }

            
        }
    }

    private void Start()
    {
        simdikiOda = 1;
        oncekiOda = 4;
        SimdikiDurum = State.Normal;
    }

    private void Update()
    {
        if (simdikiOda != oncekiOda)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/wall" + MevcutOda);
            oncekiOda = simdikiOda;
        }
    }
}
