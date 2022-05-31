using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    private DisplayImage mevcutDisplay;
    private float ilkKameraBoyutu;
    private Vector3 ilkKameraPozisyonu;

    private void Start()
    {
        mevcutDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        ilkKameraBoyutu = Camera.main.orthographicSize;
        ilkKameraPozisyonu = Camera.main.transform.position;
    }

    public void SagTiklamaTusu()
    {
        mevcutDisplay.MevcutOda += 1;
    }

    public void SolTiklamaTusu()
    {
        mevcutDisplay.MevcutOda -= 1;
    }

    public void OnClickReturn() 
    {
        if (mevcutDisplay.SimdikiDurum == DisplayImage.State.Zoomed)
        {
            GameObject.Find("displayImage").GetComponent<DisplayImage>().SimdikiDurum = DisplayImage.State.Normal;
            ZoomInObject[] zoomedObjects = FindObjectsOfType<ZoomInObject>();

            foreach (ZoomInObject obj in zoomedObjects)
            {
                obj.gameObject.layer = 0;
            }

            Camera.main.orthographicSize = ilkKameraBoyutu;
            Camera.main.transform.position = ilkKameraPozisyonu;
        }
        else if (mevcutDisplay.SimdikiDurum == DisplayImage.State.GorunumuDegis)
        {
            mevcutDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/wall" + mevcutDisplay.MevcutOda);
        }

        mevcutDisplay.SimdikiDurum = DisplayImage.State.Normal;
    }

    public void OnClickPlay() 
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OnClickExit() 
    {
        Application.Quit();
    }
}
