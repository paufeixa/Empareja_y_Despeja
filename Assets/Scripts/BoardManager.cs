using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour
{
    public int columns = 6;
    public int rows = 8;
    public GameObject[] cards;

    private Transform boardHolder;
    private List<Vector3> gridPositions = new List<Vector3>();

    void InitialiseList()
    {
        gridPositions.Clear();

        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                gridPositions.Add(new Vector3(x, y, 0f));
            }
        }
    }

    void BoardSetup()
    {
        boardHolder = new GameObject("Board").transform;
        int cardsCount = Convert.ToInt32(rows * columns);
        List<Vector3> gridPositionsAuxiliar = gridPositions;

        for (int i = 0; i < cards.Length; i++)
        {
            for (int x = 0; x < (cardsCount / cards.Length); x++)
            {
                int index = Random.Range(0, gridPositionsAuxiliar.Count);
                Vector3 randomPosition = gridPositionsAuxiliar[index];
                gridPositionsAuxiliar.RemoveAt(index);
                GameObject toInstantiate = cards[i];
                GameObject instance = Instantiate(toInstantiate, randomPosition, Quaternion.identity) as GameObject;
                instance.transform.SetParent(boardHolder);
            }
        }
    }

    public void SetupScene()
    {
        InitialiseList();
        BoardSetup();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
