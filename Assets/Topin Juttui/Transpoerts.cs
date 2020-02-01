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

    void TravellingInfect()
    {
        GameObject[] transports;
        transports = GameObject.FindGameObjectsWithTag("transport");

        float chanceRoll = Random.Range(0.0f, 100.0f);

        outsidespread = GameObject.Find("Maa" + transportCountryId).GetComponent<Country>().outsideSpreadChance * GameObject.Find("asia").GetComponent<Plague>().outsideChance;


        float travelChance = outsidespread * infectMultiplier * traffic;

        if (chanceRoll < travelChance)
        {
            int transportroll = Random.Range(0, transports.Length);

            float countryId = GameObject.Find("transport" + transportroll).GetComponent<Transpoerts>().transportCountryId;

            int infectedRoll = (Random.Range(1, 10));

            GameObject.Find("Maa" + countryId).GetComponent<Country>().numberOfHealthy -= infectedRoll;
            GameObject.Find("Maa" + countryId).GetComponent<Country>().numberOfInfected += infectedRoll;
            Debug.Log("joku oksensi koneessa");

        }
    }
}





