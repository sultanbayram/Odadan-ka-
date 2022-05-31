using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    float bagliPozisyonX;
    float bagliPozisyonY;

    float kameraPozisyonX;
    float kameraPozisyonY;

    float ustSinirKordinatı;
    float sagSinirKordinatı;
    float altSinirKordinatı;
    float solSinirKordinatı;

    float ustKameraKordinatı;
    float sagKameraKordinatı;
    float altKameraKordinatı;
    float solKameraKordinatı;

    BoxCollider2D boundCollider;

    private void Kurmak() 
    {
        boundCollider = GetComponent<BoxCollider2D>();

        float height = Camera.main.orthographicSize;
        float width = Camera.main.aspect * height;

        kameraPozisyonX = Camera.main.transform.position.x;
        kameraPozisyonY = Camera.main.transform.position.y;

        ustKameraKordinatı = kameraPozisyonY + height;
        altKameraKordinatı = kameraPozisyonY - height;
        sagKameraKordinatı = kameraPozisyonX + width;
        solKameraKordinatı = kameraPozisyonX - width;

        bagliPozisyonX = transform.position.x;
        bagliPozisyonY = transform.position.y;

        ustSinirKordinatı = bagliPozisyonY + boundCollider.size.y / 2;
        altSinirKordinatı = bagliPozisyonY - boundCollider.size.y / 2;
        sagSinirKordinatı = bagliPozisyonX + boundCollider.size.x / 2;
        solSinirKordinatı = bagliPozisyonX - boundCollider.size.x / 2;
    }

    public void KisitlamayiKontrolEt() 
    {
        Kurmak();

        if (CaprazUstKisitlama(out float diffTop)) 
        {
            MoveCamera(new Vector3(0, diffTop, 0));
        }

        if (CaprazSagKisitlama(out float diffRight))
        {
            MoveCamera(new Vector3(diffRight, 0, 0));
        }

        if (CaprazAltKisitlama(out float diffBottom))
        {
            MoveCamera(new Vector3(0, diffBottom, 0));
        }

        if (CaprazSolKisitlama(out float diffLeft))
        {
            MoveCamera(new Vector3(diffLeft, 0, 0));
        }
    }

    private bool CaprazUstKisitlama(out float diff)
    {
        diff = ustSinirKordinatı - ustKameraKordinatı;

        if (ustKameraKordinatı > ustSinirKordinatı)
        {
            return true;
        }
        else
        { 
            return false;
        }
    }
    private bool CaprazSagKisitlama(out float diff)
    {
        diff = sagSinirKordinatı - sagKameraKordinatı;

        if (sagKameraKordinatı > sagSinirKordinatı)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private bool CaprazAltKisitlama(out float diff) 
    {
        diff = altSinirKordinatı - altKameraKordinatı;

        if (altKameraKordinatı < altSinirKordinatı)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private bool CaprazSolKisitlama(out float diff) 
    {
        diff = solSinirKordinatı - solKameraKordinatı;

        if (solKameraKordinatı < solSinirKordinatı)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void MoveCamera(Vector3 vector) 
    {
        Camera.main.transform.position += vector;
    }
}
