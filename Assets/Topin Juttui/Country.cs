using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Country : MonoBehaviour
{
    private Plague plague;



    public int id;
    List<int> neighbourIds = new List<int>();
    float outsideSpreadChance;
    float insideSpreadChance;

    public float wealth;   // 0 to 2?
    public float density;  // 0 to 2?
    public float tourism;  // 0 to 2?
    public bool EU;

    public int populationTotal;
    public int numberOfHealthy;
    public int numberOfInfected;
    public int numberOfDeah;
    public int numberOfVaccinated;
    public int numberOfTransports;

    public int sentVaccinessPerSent;


    void Start()
    {

    }


    void Awake()
    {
        plague = GetComponent<Plague>();

    }

    void Update()
    {

    }



    void SpreadInside()
    {
        float plagueInsideChance = plague.insideChance;

        if (numberOfHealthy <= 0)
        {
            float chanceRoll = Random.Range(0.0f, 100.0f);

            float infectChance = insideSpreadChance * plagueInsideChance * density;

            if (infectChance > chanceRoll)
            {
                float infectedRoll = Random.Range(1.0f, 6.0f);
                float infectedPeopleF = (numberOfHealthy / 100 * infectChance) * infectedRoll;
                int infectedPeople = (int)infectedPeopleF;
                infectedPeople = infectedPeople + (populationTotal / 200);

                numberOfHealthy = numberOfHealthy - infectedPeople;
                numberOfInfected = numberOfInfected + infectedPeople;

            }

        }
    }

    void SpreadOutside()
    {

        float plagueOutsideChance = plague.outsideChance;

        if (numberOfHealthy <= 0)
        {


            float chanceRoll = Random.Range(0.0f, 100.0f);

            float infectChance = outsideSpreadChance * plagueOutsideChance * tourism;

            if (infectChance > chanceRoll)
            {

                float infectedPeople = (numberOfHealthy / 100 * infectChance);
                infectedPeople = infectedPeople + (populationTotal / 200);
            }
        }

    }



}
