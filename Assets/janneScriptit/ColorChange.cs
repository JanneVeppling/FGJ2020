using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    SpriteRenderer sprite;
    private float redness;
    private float population, infected, dead;


    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        population = gameObject.GetComponent<Country>().populationTotal;
    }

    void Update()
    {
        infected = gameObject.GetComponent<Country>().numberOfInfected;
        dead = gameObject.GetComponent<Country>().numberOfDeah;
        redness = (infected + dead)/population;
        sprite.color = new Color(1,0,0,redness);
    }
}