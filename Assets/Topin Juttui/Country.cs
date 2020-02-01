using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Country : MonoBehaviour
{


    public int id;
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

    void SpreadInside()
    {
        float plagueInsideChance = GameObject.Find("asia").GetComponent<Plague>().insideChance;

        float currenteHealthPercent = (numberOfHealthy / populationTotal) * 100f;

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
                float infectedpercentageincrease = 1 + (numberOfInfected / populationTotal); //multiplier based on % of infected people

                infectedPeople = (infectedPeople + infectedRoll) * infectedpercentageincrease;

                numberOfHealthy = numberOfHealthy - infectedPeople;
                numberOfInfected = numberOfInfected + infectedPeople;
            }
        }
    }

    void SpreadOutside()
    {
        int neighbourRoll = Random.Range(0, neighbourIds.Count);

        float plagueOutsideChance = GameObject.Find("asia").GetComponent<Plague>().outsideChance;

        float healthy = GameObject.Find("asia" + neighbourRoll).GetComponent<Country>().numberOfHealthy;

        if (healthy <= 0f)
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

                GameObject.Find("asia" + neighbourRoll).GetComponent<Country>().numberOfHealthy -= infectedPeople;
                GameObject.Find("asia" + neighbourRoll).GetComponent<Country>().numberOfInfected += infectedPeople;
            }
        }
    }
    public void DeathChance()
    {
              
       float deathchance = (GameObject.Find("asia").GetComponent<Plague>().deathchance * (Random.Range(0f, 200f)/100));

        float deadpeople= 0f;
       deadpeople = numberOfInfected * deathchance;

        numberOfInfected -= deadpeople;
        numberOfDeah += deadpeople;
        Debug.Log(deadpeople + "has died");
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
