using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Country : MonoBehaviour
{
    private Plague plague;

    public float id;
    public string worldName;
    public List<float> neighbourIds = new List<float>();
    public float neighbourCount = 0;
    public float outsideSpreadChance;
    public float insideSpreadChance;
    public float percentageMultiplier = 1f;


    public float wealth;   // 0.5 to 2?
    public float density;  // 0.5 to 2?
    public float tourism;  // 0.5 to 2?
    public bool EU;

    public float populationTotal;
    public float numberOfHealthy;
    public float numberOfInfected;
    public float numberOfDeah;
    public float numberOfVaccinated;
    public float numberOfTransports;

    public float sentVaccinessPerSent;


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
<<<<<<< HEAD
=======

        foreach (float neighbour in neighbourIds)
        {
            neighbourCount++;

        }

>>>>>>> fdf663d2e5a8e27537d6d477c69ff5ef4040a840
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


        if (numberOfHealthy <= 0f)
        {
            float chanceRoll = Random.Range(0.0f, 100.0f);

            float infectChance = insideSpreadChance * plagueInsideChance * density * percentageMultiplier;

            if (infectChance > chanceRoll)
            {
                float infectedRoll = (Random.Range(10f, 100f));
                float infectedPeople = (numberOfHealthy / 100 * infectChance) * percentageMultiplier;
                float infectedpercentageincrease =  1 + (numberOfInfected / populationTotal); //multiplier based on % of infected people

                infectedPeople = (infectedPeople + infectedRoll) * infectedpercentageincrease;
                

                numberOfHealthy = numberOfHealthy - infectedPeople;
                numberOfInfected = numberOfInfected + infectedPeople;
            }

        }
    }

    void SpreadOutside()
    {
        float neighbourRoll =(float) Random.Range(0, neighbourIds.Count);


        float plagueOutsideChance = plague.outsideChance;

        if (neighbourIds[neighbourRoll].numberOfHealthy <= 0f) //NeighbourID numberofhealthy
        {
           
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
                
                float infectedRoll = (Random.Range(2f, 100f));
                float infectedPeople = (numberOfHealthy / 200f * infectChance) * percentageMultiplier;
         

                float infectedpercentageincrease = 1 + (numberOfInfected / populationTotal); //multiplier based on % of infected people

                infectedPeople = infectedPeople + infectedRoll;


                neighbourIds[neighbourRoll].numberOfHealthy = numberOfHealthy - infectedPeople;
                neighbourIds[neighbourRoll].numberOfInfected = numberOfInfected + infectedPeople;

            }
        }

    }

<<<<<<< HEAD
    void OnMouseDown()
=======
    public Country(float id, string worldName, List<float> neighbourIds, float outsideSpreadChance, float insideSpreadChance, float wealth, float density, float tourism, bool eU, float populationTotal, float numberOfHealthy, float numberOfInfected, float numberOfDeah, float numberOfVaccinated, float numberOfTransports, float sentVaccinessPerSent)
>>>>>>> fdf663d2e5a8e27537d6d477c69ff5ef4040a840
    {
        GameObject.Find("GameController").GetComponent<UIController>().SetUI(populationTotal, numberOfHealthy, numberOfInfected, numberOfDeah, numberOfVaccinated);
    }
}
