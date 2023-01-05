using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClick : MonoBehaviour
{

    void OnMouseDown()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        SpriteRenderer card = gameObject.GetComponent<SpriteRenderer>();
        GameManager.instance.SelectCard(card, mousePos);
    }
}
