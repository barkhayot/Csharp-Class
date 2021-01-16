using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameObj : MonoBehaviour
{
    public bool Energy;
    public Text numberOfStar;
    [SerializeField]
    private Transform [] CityBoardPosition;
    private Vector2 initialPosition;

    private Vector2 mousePosition;

    private float deltaX, deltaY;

    private static bool locked;
    int n = 0;

    // just for initialization
    void Start()
    {
        initialPosition = transform.position;
    }


    private void OnMouseDown()
    {

            deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        locked = false;
        
    }

    private void OnMouseDrag()
    {
        
           mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
           transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);
        
    }

    private void OnMouseUp()
    {
        
            for (int i = 0; i < CityBoardPosition.Length; i++)
            {

                if (Mathf.Abs(transform.position.x - CityBoardPosition[i].position.x) <= 0.5f &&
                                Mathf.Abs(transform.position.y - CityBoardPosition[i].position.y) <= 0.5f)
                {
                    if (Energy)
                    {
                        Destroy(gameObject);
                        n++;
                        numberOfStar.text = "X" + n;
                    }
                    else
                        transform.position = new Vector2(CityBoardPosition[i].position.x, CityBoardPosition[i].position.y);

                    locked = true;
                }

            }
        if (!locked)
        {
            transform.position = new Vector2(initialPosition.x, initialPosition.y);
        }

    }
}
