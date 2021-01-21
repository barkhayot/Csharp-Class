using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityTiles : MonoBehaviour
{
    public bool adjacent;
    public bool select;
    public GameObject Tile;
    public List<Transform> allocation;

    private List<string> listOfSquare;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Tile != null)
            adjacent = true;

        bool adjacency = false;
        string[] name = gameObject.name.ToString().Split(' ');
        int num = int.Parse(name[1]);
        List<int> fourSide = new List<int>() { -1, 1, -5, 5 };
        foreach (int x in fourSide)
        {
            GameObject sq = GameObject.Find("square " + (num + x));
            if (sq != null)
            {
                adjacency |= sq.GetComponent<CityTiles>().adjacent;
            }

        }
        
        if (adjacency && select)
            gameObject.GetComponent<Renderer>().material.color = Color.green;
    }
}
