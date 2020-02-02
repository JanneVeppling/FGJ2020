using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public string worldName;
    public float population;
    public float healthy;
    public float infected;
    public float vaccinated;
    public float dead;

    public GameObject[] countries;

    // Start is called before the first frame update
    void Start()
    {
        countries = GameObject.FindGameObjectsWithTag("Country");

        foreach (GameObject country in countries)
        {
            population += country.GetComponent<Country>().populationTotal;
            healthy += country.GetComponent<Country>().numberOfHealthy;
            infected += country.GetComponent<Country>().numberOfInfected;
            vaccinated += country.GetComponent<Country>().numberOfVaccinated;
            dead += country.GetComponent<Country>().numberOfDeah;
        }
        GameObject.Find("GameController").GetComponent<UIController>().SetUI(worldName, population, healthy, infected, dead, vaccinated);
    }

    public void GetWorldStats()
    {
        healthy = 0;
        infected = 0;
        vaccinated = 0;
        dead = 0;

        foreach (GameObject country in countries)
        {
            healthy += country.GetComponent<Country>().numberOfHealthy;
            infected += country.GetComponent<Country>().numberOfInfected;
            vaccinated += country.GetComponent<Country>().numberOfVaccinated;
            dead += country.GetComponent<Country>().numberOfDeah;
        }
    }

    void OnMouseDown()
    {
        if (gameObject.CompareTag("Maapallo"))
        {
            GameObject.Find("GameController").GetComponent<UIController>().SetUI(worldName, population, healthy, infected, dead, vaccinated);
            GameObject.Find("GameController").GetComponent<Player>().currentSelecetedWorld = 0;
        }
    }
}
