using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Country : MonoBehaviour
{
    private Plague plague;

    public int id;
    public string worldName;
    public List<int> neighbourIds = new List<int>();
    float outsideSpreadChance;
    float insideSpreadChance;
    float percentageMultiplier = 1f;


    public float wealth;   // 0.5 to 2?
    public float density;  // 0.5 to 2?
    public float tourism;  // 0.5 to 2?
    public bool EU;

    public int populationTotal;
    public int numberOfHealthy;
    public int numberOfInfected;
    public int numberOfDeah;
    public int numberOfVaccinated;
    public int numberOfTransports;

    public int sentVaccinessPerSent;


    //public List<Country> countries = new List<Country>();

    void Start()
    {
        //Idea toistaiseksi paussilla
       /* countries.Add(new Country(0, "World", neighbourIds, 0, 0, 0, 0, 0, false, 1000000, 1000000, 0, 0, 0, 0, 0));
        countries.Add(new Country(1, "Kissala", neighbourIds, 0, 0, 0, 0, 0, false, 1000, 1000, 0, 0, 0, 0, 0));
        countries.Add(new Country(2, "Turuk", neighbourIds, 0, 0, 0, 0, 0, false, 7000, 7000, 0, 0, 0, 0, 0));
        */
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

        float  currenteHealthPercent = (numberOfHealthy / populationTotal) * 100f;

        if (currenteHealthPercent > 98 || currenteHealthPercent < 2) percentageMultiplier = 0.2f;
        else if (currenteHealthPercent > 95 & currenteHealthPercent < 98 || currenteHealthPercent > 2 & currenteHealthPercent < 5) percentageMultiplier = 0.4f;
        else if (currenteHealthPercent > 85 & currenteHealthPercent < 95 || currenteHealthPercent > 5 & currenteHealthPercent < 15) percentageMultiplier = 0.6f;
        else if (currenteHealthPercent > 70 & currenteHealthPercent < 85 || currenteHealthPercent > 15 & currenteHealthPercent < 30) percentageMultiplier = 1.0f;
        else if (currenteHealthPercent > 60 & currenteHealthPercent < 70 || currenteHealthPercent > 30 & currenteHealthPercent < 40) percentageMultiplier = 1.3f;
        else if (currenteHealthPercent > 50 & currenteHealthPercent < 60 || currenteHealthPercent > 40 & currenteHealthPercent < 50) percentageMultiplier = 1.8f;

        if (numberOfHealthy <= 0)
        {
            float chanceRoll = Random.Range(0.0f, 100.0f);

            float infectChance = insideSpreadChance * plagueInsideChance * density * percentageMultiplier;

            if (infectChance > chanceRoll)
            {
                int infectedRoll = (Random.Range(20, 400));
                float infectedPeopleF = (numberOfHealthy / 100 * infectChance) * percentageMultiplier;
                int infectedPeople = (int)infectedPeopleF;
                infectedPeople = infectedPeople + infectedRoll;
                

                numberOfHealthy = numberOfHealthy - infectedPeople;
                numberOfInfected = numberOfInfected + infectedPeople;
            }

        }
    }

    void SpreadOutside()
    {

        float plagueOutsideChance = plague.outsideChance;

        if (numberOfHealthy <= 0) //NeighbourID numberofhealthy
        {
            //muuta kaikki neighborin alle
            float currenteHealthPercent = (numberOfHealthy / populationTotal) * 100f;

           
            if (currenteHealthPercent > 98 || currenteHealthPercent < 2) percentageMultiplier = 0.2f;
            else if (currenteHealthPercent > 95 & currenteHealthPercent < 98 || currenteHealthPercent > 2 & currenteHealthPercent < 5) percentageMultiplier = 0.4f;
            else if (currenteHealthPercent > 85 & currenteHealthPercent < 95 || currenteHealthPercent > 5 & currenteHealthPercent < 15) percentageMultiplier = 0.6f;
            else if (currenteHealthPercent > 70 & currenteHealthPercent < 85 || currenteHealthPercent > 15 & currenteHealthPercent < 30) percentageMultiplier = 1.0f;
            else if (currenteHealthPercent > 60 & currenteHealthPercent < 70 || currenteHealthPercent > 30 & currenteHealthPercent < 40) percentageMultiplier = 1.3f;
            else if (currenteHealthPercent > 50 & currenteHealthPercent < 60 || currenteHealthPercent > 40 & currenteHealthPercent < 50) percentageMultiplier = 1.8f;



            float chanceRoll = Random.Range(0.0f, 100.0f);

            float infectChance = outsideSpreadChance * plagueOutsideChance * tourism * percentageMultiplier;

            if (infectChance > chanceRoll)
            {
                //kaikki muuttujat neighbour.id jutun alle!!
                int infectedRoll = (Random.Range(2, 100));
                float infectedPeopleF = (numberOfHealthy / 200 * infectChance) * percentageMultiplier;
                int infectedPeople = (int)infectedPeopleF;
                infectedPeople = infectedPeople + infectedRoll;
                

                numberOfHealthy = numberOfHealthy - infectedPeople;
                numberOfInfected = numberOfInfected + infectedPeople;

            }
        }

    }

    void OnMouseDown()
    {
        GameObject.Find("GameController").GetComponent<UIController>().SetUI(populationTotal, numberOfHealthy, numberOfInfected, numberOfDeah, numberOfVaccinated);
    }
}
