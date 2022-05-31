using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Path : MonoBehaviour
{
    [SerializeField]
    private Transform pathPlace;
    private Vector2 initialPosition;
    private Vector2 mousePosition;
    private float deltaX, deltaY;
    public static bool locked;
    //bunu baþlatma için kullan
    private void Start()
    {
        initialPosition = transform.position;
    }
    private void OnMouseDown()
    {
        if (!locked)
        {
            deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        }
    }

    private void OnMouseDrag()
    {
        if (!locked)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);
        }
    }
    private void OnMouseUp()
    {
        if (Mathf.Abs(transform.position.x - pathPlace.position.x) <= 0.5f &&
            Mathf.Abs(transform.position.y - pathPlace.position.y) <= 0.5f)
        {
            transform.position = new Vector2(pathPlace.position.x, pathPlace.position.y);
            locked = true;
        }
        else
        {
            transform.position = new Vector2(initialPosition.x, initialPosition.y);
        }
    }
}