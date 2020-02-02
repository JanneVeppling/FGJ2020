using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transpoerts : MonoBehaviour
{
    private Country country;

    public int id;
    public float transportCountryId;
    public float traffic;
    public float infectMultiplier;
    public float outsidespread;

    public List<float> TransportIDs = new List<float>();

    public void TravellingInfect()
    {
        GameObject[] transports;
        transports = GameObject.FindGameObjectsWithTag("Country");

        float chanceRoll = Random.Range(0.0f, 50.0f);

        outsidespread = GameObject.Find("GameController").GetComponent<Plague>().outsideChance;


        float travelChance = outsidespread * infectMultiplier * traffic;

        if (chanceRoll < travelChance)
        {
            int transportroll = Random.Range(0, transports.Length);

            float countryId = GameObject.Find("Maa" + transportroll).GetComponent<Country>().id;

            int infectedRoll = (Random.Range(1, 10));

            GameObject.Find("Maa" + countryId).GetComponent<Country>().numberOfHealthy -= infectedRoll;
            GameObject.Find("Maa" + countryId).GetComponent<Country>().numberOfInfected += infectedRoll;
          
        }
    }
}





