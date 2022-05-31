using UnityEngine;
using UnityEngine.EventSystems;

public class Block : MonoBehaviour, IDragHandler, IDropHandler
{
    public int dogruKutuIndeksi;
    public int KutuIndeksi { get; private set; }

    Vector3 ilkPozisyon;

    void Start() 
    {
        KutuIndeksi = -1;
        ilkPozisyon = transform.position;
        gameObject.SetActive(false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (GameObject.Find("Scale").GetComponent<Scale>().isSolved) return;
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
    }

    public void OnDrop(PointerEventData eventData)
    {
        Scale scale = GameObject.Find("Scale").GetComponent<Scale>();
        bool dropInsideOfBox = false;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        for (int i = 0;i< scale.GetComponent<Scale>().scaleBoxes.Length; i++) 
        {
            if ( 
                mousePosition.x <= (scale.GetComponent<Scale>().scaleBoxes[i].transform.position.x + scale.GetComponent<Scale>().scaleBoxes[i].GetComponent<BoxCollider2D>().size.x/2) &&
                mousePosition.x >= (scale.GetComponent<Scale>().scaleBoxes[i].transform.position.x - scale.GetComponent<Scale>().scaleBoxes[i].GetComponent<BoxCollider2D>().size.x / 2) &&
                mousePosition.x <= (scale.GetComponent<Scale>().scaleBoxes[i].transform.position.y + scale.GetComponent<Scale>().scaleBoxes[i].GetComponent<BoxCollider2D>().size.y / 2 )&&
                mousePosition.x >= (scale.GetComponent<Scale>().scaleBoxes[i].transform.position.y - scale.GetComponent<Scale>().scaleBoxes[i].GetComponent<BoxCollider2D>().size.y / 2 )
                )
            {
                transform.position = new Vector3(scale.GetComponent<Scale>().scaleBoxes[i].transform.position.x,
                    scale.GetComponent<Scale>().scaleBoxes[i].transform.position.y,transform.position.z);
                KutuIndeksi = i;
                dropInsideOfBox = true;
            }
        }

        if (!dropInsideOfBox)
        {
            transform.position = ilkPozisyon;
            KutuIndeksi = -1;
        }
    }
}
