using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClick : MonoBehaviour
{
    private Sprite card1;
    private Sprite card2;

    void OnMouseDown()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        if (card1 == null)
        {
            card1 = gameObject.GetComponent<SpriteRenderer>().sprite;
        }
        else if (card2 == null)
        {
            card2 = gameObject.GetComponent<SpriteRenderer>().sprite;
            if (card1 == card2)
            {
            }
            else
            {
            }
            card1 = null;
            card2 = null;
        }
    }
}
