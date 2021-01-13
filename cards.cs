using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cards : MonoBehaviour
{
    [SerializeField]
     private GameObject[] card;
    int randomCard = 0;
    public List<int> randomList = new List<int>();
    private Vector2 posTile;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < card.Length; i++)
        {
            while (true)
            {
                randomCard = Random.Range(0, card.Length);
                if (!randomList.Contains(randomCard))
                {
                    randomList.Add(randomCard);
                    break;
                }
            }
            posTile = new Vector2(transform.position.x + i * 2, transform.position.y);
            Instantiate(card[randomCard], posTile, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
