using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transpoerts : MonoBehaviour
{
    private Country country;

    int id;
    float traffic;
    float infectMultiplier;
    float outsidespread;


    void Awake()
    {
        country = GetComponent<Country>();

    }

   void TravellingInfect()
    {
        float chanceRoll = Random.Range(0.0f, 100.0f);

        outsidespread = country.outsideSpreadChance;

        float travelChance;
        travelChance = outsidespread * infectMultiplier;


        if (chanceRoll < travelChance)
        {
            int infectedRoll = (Random.Range(1, 10));


        }



    }


}
