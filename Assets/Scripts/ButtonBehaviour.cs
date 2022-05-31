using UnityEngine;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
    public enum ButtonType { RoomChangeButton, ReturnButton }
    public ButtonType ButonTipi;
    private DisplayImage mevcutDisplay;
    private Image image;
    private Button button;

    private void Start()
    {
        mevcutDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        image = GetComponent<Image>();
        button = GetComponent<Button>();
    }

    private void Update()
    {
        DoBehaviour();
    }

    private void DoBehaviour() 
    {
        if (mevcutDisplay.SimdikiDurum == DisplayImage.State.Normal)
        {
            if (ButonTipi == ButtonType.ReturnButton)
            {
                Gizle();
                //this.transform.SetSiblingIndex(0);
            }
            else if (ButonTipi == ButtonType.RoomChangeButton)
            {
                Display();
            }
        }
        else if (mevcutDisplay.SimdikiDurum != DisplayImage.State.Normal) 
        {
            if (ButonTipi == ButtonType.ReturnButton)
            {
                Display();
            }
            else if (ButonTipi == ButtonType.RoomChangeButton)
            {
                Gizle();
            }
        }
    }

    void Gizle() 
    {
        image.color = new Color(image.color.r, image.color.r, image.color.r, 0);
        button.enabled = false;
    }

    void Display() 
    {
        image.color = new Color(image.color.r, image.color.r, image.color.r, 1);
        button.enabled = true;
    }
}
