using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour
{
    public int columns = 6;
    public int rows = 8;
    public GameObject[] cards;

    private List<Sprite> displayedCards = new List<Sprite>();
    private Transform boardHolder;
    private List<Vector3> gridPositions = new List<Vector3>();
    private List<Vector3> gridPositionsAuxiliar = new List<Vector3>();

    void InitialiseList()
    {
        gridPositions.Clear();
        gridPositionsAuxiliar.Clear();

        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns; x++)
            {
                gridPositions.Add(new Vector3(x, y, 0f));
                gridPositionsAuxiliar.Add(new Vector3(x, y, 0f));
            }
        }
    }

    void DisplayedCardsInit()
    {
        displayedCards.Clear();
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns; x++)
            {
                displayedCards.Add(null);
            }
        }
    }

    void BoardSetup()
    {
        boardHolder = new GameObject("Board").transform;
        int cardsCount = Convert.ToInt32(rows * columns);

        for (int i = 0; i < cards.Length; i++)
        {
            for (int x = 0; x < (cardsCount / cards.Length); x++)
            {
                int index = Random.Range(0, gridPositionsAuxiliar.Count);
                Vector3 randomPosition = gridPositionsAuxiliar[index];
                gridPositionsAuxiliar.RemoveAt(index);
                int indexDisplayed = gridPositions.IndexOf(randomPosition);
                displayedCards[indexDisplayed] = cards[i].GetComponent<SpriteRenderer>().sprite;
                GameObject toInstantiate = cards[i];
                GameObject instance = Instantiate(toInstantiate, randomPosition, Quaternion.identity) as GameObject;
                instance.transform.SetParent(boardHolder);
            }
        }
    }

    public void SetupScene()
    {
        InitialiseList();
        DisplayedCardsInit();
        BoardSetup();
    }

    public bool Near(Vector3 position1, Vector3 position2)
    {
        double distance = Math.Pow((position2[0] - position1[0]), 2) + Math.Pow((position2[1] - position1[1]), 2);
        if (distance <= 2 && distance != 0)
        {
            return true;
        }
        else
            return false;
    }

    public void BoardUpdate(Vector3 position1, Vector3 position2)
    {
        int index1 = gridPositions.IndexOf(position1);
        int index2 = gridPositions.IndexOf(position2);
        if (index1 > index2)
        {
            displayedCards.RemoveAt(index1);
            displayedCards.RemoveAt(index2);
        }
        if (index1 < index2)
        {
            displayedCards.RemoveAt(index2);
            displayedCards.RemoveAt(index1);
        }
        gridPositions.RemoveAt(gridPositions.Count-1);
        gridPositions.RemoveAt(gridPositions.Count-1);
        Destroy(boardHolder.gameObject);
        boardHolder = new GameObject("Board").transform;
        for (int i = 0; i < gridPositions.Count; i++)
        {
            int x = 0;
            bool found = false;
            while (x < cards.Length && !found)
            {
                if (cards[x].GetComponent<SpriteRenderer>().sprite == displayedCards[i])
                {
                    GameObject toInstantiate = cards[x];
                    GameObject instance = Instantiate(toInstantiate, gridPositions[i], Quaternion.identity) as GameObject;
                    instance.transform.SetParent(boardHolder);
                    found = true;
                }
                x++;
            }
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
