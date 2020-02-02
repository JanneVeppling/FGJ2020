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
    public float currenteHealthPercent;

    public float wealth = 1;   // 0.5 to 2?
    public float density = 1;  // 0.5 to 2?
    public float tourism = 1;  // 0.5 to 2?
    

    public int populationTotal;
    public int numberOfHealthy;
    public int numberOfInfected;
    public int numberOfDeah;
    public int numberOfVaccinated;
    public int numberOfTransports;
    int mutacounter = 0;
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
            DeathChance();
            


           //  GameObject.Find("Maa" + id).GetComponent<Transpoerts>().TravellingInfect();
            this.gameObject.GetComponent<Transpoerts > ().TravellingInfect();
            if (mutacounter == 1) mutacounter = 0;   
            else GameObject.Find("GameController").GetComponent<Plague>().Mutate();
            
              targetTime = 1.3f;         
        }
    }


    void SpreadInside()
    {
        float plagueInsideChance = GameObject.Find("GameController").GetComponent<Plague>().insideChance;
 

        currenteHealthPercent = (numberOfHealthy / populationTotal) * 100f;
        //Debug.Log( numberOfHealthy + " " + populationTotal + " " + currenteHealthPercent + "persentti");


        if (currenteHealthPercent > 98 || currenteHealthPercent < 2) percentageMultiplier = 0.15f;
        else if (currenteHealthPercent > 95 & currenteHealthPercent < 98 || currenteHealthPercent > 2 & currenteHealthPercent < 5) percentageMultiplier = 0.25f;
        else if (currenteHealthPercent > 85 & currenteHealthPercent < 95 || currenteHealthPercent > 5 & currenteHealthPercent < 15) percentageMultiplier = 0.35f;
        else if (currenteHealthPercent > 70 & currenteHealthPercent < 85 || currenteHealthPercent > 15 & currenteHealthPercent < 30) percentageMultiplier = 0.5f;
        else if (currenteHealthPercent > 60 & currenteHealthPercent < 70 || currenteHealthPercent > 30 & currenteHealthPercent < 40) percentageMultiplier = 0.7f;
        else if (currenteHealthPercent > 50 & currenteHealthPercent < 60 || currenteHealthPercent > 40 & currenteHealthPercent < 50) percentageMultiplier = 1.0f;


        if (numberOfHealthy >= 0f)
        {
            float chanceRoll = Random.Range(0.0f, 10.0f);

            float infectChance = insideSpreadChance * plagueInsideChance * density * percentageMultiplier  ;

          

            if (infectChance > chanceRoll)
            {
                int infectedRoll = (Random.Range(1, 10));
                int infectedPeople = (int)(numberOfHealthy / 400 * infectChance);
                float infectedpercentageincrease = 1 + (numberOfInfected / populationTotal); //multiplier based on % of infected people

                infectedPeople = (int)((infectedPeople + infectedRoll) * infectedpercentageincrease);

             
           


                if (infectedPeople >= numberOfHealthy)
                {
                    infectedPeople = numberOfHealthy;
                 

                }

                numberOfHealthy -=  infectedPeople;
                numberOfInfected += infectedPeople;
              

            }
        }
    }

    void SpreadOutside()
    {
        int neighbourRoll = (Random.Range(1, 21)); ;
          
    

        float plagueOutsideChance = GameObject.Find("GameController").GetComponent<Plague>().outsideChance;

        if (id != 3) // koska maata numero 3 ei ole olemassa
        {
            int healthy = GameObject.Find("Maa" + neighbourRoll).GetComponent<Country>().numberOfHealthy;
            Debug.Log(healthy + "asdasd");
      
      

        if (healthy > 0)
        {

            float currenteHealthPercent = (numberOfHealthy / populationTotal) * 100f;

            if (currenteHealthPercent > 98 || currenteHealthPercent < 2) percentageMultiplier = 0.15f;
            else if (currenteHealthPercent > 95 & currenteHealthPercent < 98 || currenteHealthPercent > 2 & currenteHealthPercent < 5) percentageMultiplier = 0.25f;
            else if (currenteHealthPercent > 85 & currenteHealthPercent < 95 || currenteHealthPercent > 5 & currenteHealthPercent < 15) percentageMultiplier = 0.35f;
            else if (currenteHealthPercent > 70 & currenteHealthPercent < 85 || currenteHealthPercent > 15 & currenteHealthPercent < 30) percentageMultiplier = 0.5f;
            else if (currenteHealthPercent > 60 & currenteHealthPercent < 70 || currenteHealthPercent > 30 & currenteHealthPercent < 40) percentageMultiplier = 0.7f;
            else if (currenteHealthPercent > 50 & currenteHealthPercent < 60 || currenteHealthPercent > 40 & currenteHealthPercent < 50) percentageMultiplier = 1.0f;

            float chanceRoll = Random.Range(0.0f, 10.0f);

            float infectChance = outsideSpreadChance * plagueOutsideChance * tourism * percentageMultiplier ;

            if (infectChance > chanceRoll)
            {

                float infectedRoll = (Random.Range(1f, 10f));
                float infectedPeople = ((numberOfHealthy / 500f) * infectChance) * percentageMultiplier;



                infectedPeople = infectedPeople + infectedRoll;


                if (infectedPeople >= GameObject.Find("Maa" + neighbourRoll).GetComponent<Country>().numberOfHealthy)
                {
                    infectedPeople = GameObject.Find("Maa" + neighbourRoll).GetComponent<Country>().numberOfHealthy;


                }

                int infectedPeople2 = (int)infectedPeople;


                Debug.Log(neighbourRoll + "naapurirolli");
                GameObject.Find("Maa" + neighbourRoll).GetComponent<Country>().numberOfHealthy -= infectedPeople2;
                GameObject.Find("Maa" + neighbourRoll).GetComponent<Country>().numberOfInfected += infectedPeople2;
                Debug.Log(GameObject.Find("Maa" + neighbourRoll).GetComponent<Country>().id);
             
            }
        }
        }
    }
    public void DeathChance()
    {
        int chanceRoll = Random.Range(0, 100);

        if (chanceRoll < 15 )
        { 

        float deathchance = (GameObject.Find("GameController").GetComponent<Plague>().deathchance);
        Debug.Log(deathchance + " DeathChance juttu");

        int deadpeople;
        deadpeople = (int)((numberOfInfected * deathchance * deathchance) + Random.Range(1,5));



        if (numberOfInfected > 0 && deadpeople > 0)
        { 
            if (deadpeople > numberOfInfected)
            {
                deadpeople = numberOfInfected;
            }
        numberOfInfected -= deadpeople;
        numberOfDeah += deadpeople;
        Debug.Log(deadpeople + " people has died " + numberOfInfected);
        }
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
