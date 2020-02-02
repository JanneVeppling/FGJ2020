using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    SpriteRenderer sprite;
    private float redness;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        redness = (gameObject.GetComponent<Country>().numberOfInfected + gameObject.GetComponent<Country>().numberOfDeah) / gameObject.GetComponent<Country>().populationTotal;
            // Change the 'color' property of the 'Sprite Renderer'
            sprite.color = new Color(1,0,0,redness);
    }
}