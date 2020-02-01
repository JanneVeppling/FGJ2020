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

    public Country(int id, string worldName, List<int> neighbourIds, float outsideSpreadChance, float insideSpreadChance, float wealth, float density, float tourism, bool eU, int populationTotal, int numberOfHealthy, int numberOfInfected, int numberOfDeah, int numberOfVaccinated, int numberOfTransports, int sentVaccinessPerSent)
    {
        this.id = id;
        this.worldName = worldName;
        this.neighbourIds = neighbourIds;
        this.outsideSpreadChance = outsideSpreadChance;
        this.insideSpreadChance = insideSpreadChance;
        this.wealth = wealth;
        this.density = density;
        this.tourism = tourism;
        EU = eU;
        this.populationTotal = populationTotal;
        this.numberOfHealthy = numberOfHealthy;
        this.numberOfInfected = numberOfInfected;
        this.numberOfDeah = numberOfDeah;
        this.numberOfVaccinated = numberOfVaccinated;
        this.numberOfTransports = numberOfTransports;
        this.sentVaccinessPerSent = sentVaccinessPerSent;
    }
}
