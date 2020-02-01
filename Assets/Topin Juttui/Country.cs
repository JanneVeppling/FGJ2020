using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Country : MonoBehaviour
{


    public int id;
    public string worldName;
    public List<float> neighbourIds = new List<float>();
    public float neighbourCount;
    public float outsideSpreadChance = 1.2f;
    public float insideSpreadChance = 1f;
    public float percentageMultiplier = 1f;


    public float wealth;   // 0.5 to 2?
    public float density;  // 0.5 to 2?
    public float tourism;  // 0.5 to 2?
     bool EU;

    public float populationTotal;
    public float numberOfHealthy;
    public float numberOfInfected;
    public float numberOfDeah;
    public float numberOfVaccinated;
    public float numberOfTransports;

    public float sentVaccinessPerSent;


    public float targetTime = 10.0f;


    void Start()
    {
      
    }

    void Update()
    {
            targetTime -= Time.deltaTime;

            if (targetTime <= 0.0f)
            {

            SpreadInside();
            SpreadOutside();
           // DeathChance();

            GameObject.Find("GameController").GetComponent<Plague>().Mutate();
           

              targetTime = 1.0f;
            Debug.Log("Ajastin JOKA EI TOIMI");

        }
    }


    void SpreadInside()
    {
        float plagueInsideChance = GameObject.Find("GameController").GetComponent<Plague>().insideChance;

        float currenteHealthPercent = (numberOfHealthy / populationTotal) * 100f;

        if (currenteHealthPercent > 98 || currenteHealthPercent < 2) percentageMultiplier = 0.2f;
        else if (currenteHealthPercent > 95 & currenteHealthPercent < 98 || currenteHealthPercent > 2 & currenteHealthPercent < 5) percentageMultiplier = 0.4f;
        else if (currenteHealthPercent > 85 & currenteHealthPercent < 95 || currenteHealthPercent > 5 & currenteHealthPercent < 15) percentageMultiplier = 0.6f;
        else if (currenteHealthPercent > 70 & currenteHealthPercent < 85 || currenteHealthPercent > 15 & currenteHealthPercent < 30) percentageMultiplier = 1.0f;
        else if (currenteHealthPercent > 60 & currenteHealthPercent < 70 || currenteHealthPercent > 30 & currenteHealthPercent < 40) percentageMultiplier = 1.2f;
        else if (currenteHealthPercent > 50 & currenteHealthPercent < 60 || currenteHealthPercent > 40 & currenteHealthPercent < 50) percentageMultiplier = 1.5f;

        Debug.Log(numberOfHealthy + "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb");

        if (numberOfHealthy >= 0f)
        {
            float chanceRoll = Random.Range(0.0f, 100.0f);

            float infectChance = insideSpreadChance * plagueInsideChance * density * percentageMultiplier;

            if (infectChance > chanceRoll)
            {
                float infectedRoll = (Random.Range(1f, 10f));
                float infectedPeople = (numberOfHealthy / 300 * infectChance) * percentageMultiplier;
                float infectedpercentageincrease = 1 + (numberOfInfected / populationTotal); //multiplier based on % of infected people

                infectedPeople = (infectedPeople + infectedRoll) * infectedpercentageincrease;

                int infectedPeople2 = (int)infectedPeople;
                Debug.Log(infectedPeople2 + " AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
                numberOfHealthy = numberOfHealthy - infectedPeople2;
                numberOfInfected = numberOfInfected + infectedPeople2;
            }
        }
    }

    void SpreadOutside()
    {
        int neighbourRoll = Random.Range(0, neighbourIds.Count);
      //  Debug.Log(neighbourIds.Count + " ASASDASDADAS" );

        float plagueOutsideChance = GameObject.Find("GameController").GetComponent<Plague>().outsideChance;

        // int healthy =(int) GameObject.Find("Maa" + neighbourRoll).GetComponent<Country>().numberOfHealthy; //////////////////////////////////////////////
        int healthy = 10;

        if (healthy > 0)
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


              

                infectedPeople = infectedPeople + infectedRoll ;

                int infectedPeople2 = (int)infectedPeople;


                GameObject.Find("Maa" + neighbourRoll).GetComponent<Country>().numberOfHealthy -= infectedPeople2;
                GameObject.Find("Maa" + neighbourRoll).GetComponent<Country>().numberOfInfected += infectedPeople2;
            }
        }
    }
    public void DeathChance()
    {

        float deathchance = (GameObject.Find("GameController").GetComponent<Plague>().deathchance * (Random.Range(0f, 200f) / 100));
        Debug.Log(deathchance + " DeathChance juttu");

        int deadpeople;
        deadpeople = (int)(numberOfInfected * deathchance);

        if (numberOfInfected > 0)
        { 
        numberOfInfected -= deadpeople;
        numberOfDeah += deadpeople;
        Debug.Log(deadpeople + " people has died");
        }
    }

    void OnMouseDown()
    {
        if (gameObject.CompareTag("Country"))
        {
            GameObject.Find("GameController").GetComponent<UIController>().SetUI(worldName, populationTotal, numberOfHealthy, numberOfInfected, numberOfDeah, numberOfVaccinated);
            GameObject.Find("GameController").GetComponent<Player>().currentSelecetedWorld = id;
        }
    }
}
