using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject[] prefabs;
    private int randomPrefab;

    //private Touch touch;
    private Vector2 touchPos;
    private Vector2 posTile;


    public List<int> alltiles = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 144; i++)
        {
            if (i < 20)
                alltiles.Add(1);
            else
                if (i < 34)
                alltiles.Add(2);
            else
                if (i < 46)
                alltiles.Add(3);
            else
                if (i < 48)
                alltiles.Add(4);
            else
                if (i < 50)
                alltiles.Add(5);
            else
                if (i < 52)
                alltiles.Add(6);
            else
                if (i < 54)
                alltiles.Add(7);
            else
                if (i < 56)
                alltiles.Add(8);
            else
                if (i < 58)
                alltiles.Add(9);
            else
                if (i < 68)
                alltiles.Add(10);
            else
                if (i < 78)
                alltiles.Add(11);
            else
                if (i < 88)
                alltiles.Add(12);
            else
                if (i < 90)
                alltiles.Add(13);
            else
                if (i < 100)
                alltiles.Add(14);
            else
                if (i < 120)
                alltiles.Add(15);
            else
                if (i < 124)
                alltiles.Add(16);
            else
                if (i < 128)
                alltiles.Add(17);
            else
                if (i < 130)
                alltiles.Add(18);
            else
                if (i < 140)
                alltiles.Add(19);
            else
                alltiles.Add(20);

        }

        touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        int n = 14;
        int p = 0;
        int sign = 1;
        for (int i = 0; i < n; i++)
        {
            if (p == 6)
            {
                p = 0;
                sign = -1;
            }
            if (i < 12)
            {
                posTile = new Vector2(transform.position.x + (p - 2), transform.position.y + sign);
                p++;
            }
            else
                if (i == 12)
                posTile = new Vector2(transform.position.x - 2, transform.position.y);
            else
                posTile = new Vector2(transform.position.x + 3, transform.position.y);

            //Debug.Log(transform.localScale.y);

            randomPrefab = Random.Range(0, alltiles.Count);
            Debug.Log("randomePrefabs:"+randomPrefab);

            Debug.Log("tileIndex: "+alltiles[1]);

            Instantiate(prefabs[alltiles[randomPrefab]-1], posTile, Quaternion.identity);
            alltiles.RemoveAt(randomPrefab);
        }

        

        


        alltiles.Remove(randomPrefab);

    }

}
