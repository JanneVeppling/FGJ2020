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

        float chanceRoll = Random.Range(0.0f, 25.0f); // sattumanvarainen arvo lähteekö lentokone matkaan sairaiden henkilöiden kanssa

        outsidespread = GameObject.Find("GameController").GetComponent<Plague>().outsideChance;

        
        // maan turismin vaikutus todennäköisyyteen levittää sairautta joka poistettiin
        float travelChance = outsidespread * infectMultiplier * traffic;
        Debug.Log("joku oksensi koneessa2");
        if (chanceRoll < travelChance)
        {
            int transportroll = Random.Range(1, 21);
            if (transportroll != 3 ) // syystä X meiltä puuttuu maa numero 3 joten näin säästymme turhilta erroreilta
            {
       

            int infectedRoll = (Random.Range(1, 10)); //sairaiden määrä

            GameObject.Find("Maa" + transportroll).GetComponent<Country>().numberOfHealthy -= infectedRoll;
            GameObject.Find("Maa" + transportroll).GetComponent<Country>().numberOfInfected += infectedRoll;
            Debug.Log("joku oksensi koneessa"); // testi toimiiko lentokoneiden kanssa sairauden leviäminen
            }
        }
    }
}





