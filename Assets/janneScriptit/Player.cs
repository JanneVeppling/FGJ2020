using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int numOfInfectedCountries;
    public int totalFunds;
    public int passiveIncome;
    public int vaccinesPerSec;
    public float numOfVaccines;
    public bool readyToSentVaccines;
    public int currentSelecetedWorld;

    public GameObject MB2, MB3, I2, I3, VAC2, VAC3, MT2, MT3;

    public GameObject[] countries;

    void Start()
    {
        countries = GameObject.FindGameObjectsWithTag("Country");

        InvokeRepeating("AddFundsAndVaccines", 2f, 2f);

        GameObject.Find("GameController").GetComponent<Plague>();
    }

    void Update()
    {
        GameObject.Find("GameController").GetComponent<UIController>().SetMoneyAndVaccines(totalFunds, numOfVaccines);
    }

    void AddFundsAndVaccines()
    {
        totalFunds += 2 * (passiveIncome);
        numOfVaccines += 2 * (vaccinesPerSec);
    }
    #region buttonHässäkkä
    public void VaccineLevel1()
    {
        if (totalFunds >= 500)
        {
            totalFunds -= 500;
            vaccinesPerSec = 1000;
            readyToSentVaccines = true;
            VAC2.SetActive(true);
            MT2.SetActive(true);
        }
    }

    public void VaccineLevel2()
    {
        if (totalFunds >= 2000)
        {
            totalFunds -= 2000;
            vaccinesPerSec = 5000;
            VAC3.SetActive(true);
            MT3.SetActive(true);
        }
    }

    public void VaccineLevel3()
    {
        if (totalFunds >= 10000)
        {
            totalFunds -= 10000;
            vaccinesPerSec = 10000;
        }
    }

    public void MoneyLevel1()
    {
        if (totalFunds >= 500)
        {
            if (passiveIncome == 10)
            {
                passiveIncome += 10;
                totalFunds -= 500;
                MB2.SetActive(true);
                MT2.SetActive(true);
            }
        }
    }

    public void MoneyLevel2()
    {
        if (totalFunds >= 2000)
        {
            if (passiveIncome == 20)
            {
                passiveIncome += 10;
                totalFunds -= 2000;
                MB3.SetActive(true);
                MT3.SetActive(true);
            }
        }
    }

    public void MoneyLevel3()
    { 
        if (totalFunds >= 10000)
        {
            if (passiveIncome == 30)
            {
                passiveIncome += 10;
                totalFunds -= 10000;
            }
        }
    }

    public void InformationLevel1()
    {
        if (totalFunds >= 500)
        {
            gameObject.GetComponent<Plague>().insideChance *= 0.8f;
            gameObject.GetComponent<Plague>().outsideChance *= 0.8f;
            totalFunds -= 500;
            I2.SetActive(true);
            MT2.SetActive(true);
        }
    }

    public void InformationLevel2()
    {
        if(totalFunds >= 2000)
        {
            gameObject.GetComponent<Plague>().insideChance *= 0.8f;
            gameObject.GetComponent<Plague>().outsideChance *= 0.8f;
            totalFunds -= 2000;
            I3.SetActive(true);
            MT3.SetActive(true);
        }
    }

    public void InformationLevel3()
    {
        if(totalFunds >= 10000)
        {
            gameObject.GetComponent<Plague>().insideChance *= 0.8f;
            gameObject.GetComponent<Plague>().outsideChance *= 0.8f;
            totalFunds -= 10000;
        }
    }
    #endregion

    public void SendVaccines()
    {
        foreach(GameObject country in countries)
        {
            if(country.GetComponent<Country>().id == currentSelecetedWorld)
            {
                int temp = int.Parse(gameObject.GetComponent<UIController>().sendInput.text);

                if(temp <= numOfVaccines)
                {
                    if(temp <= country.GetComponent<Country>().numberOfInfected)
                    {
                        country.GetComponent<Country>().numberOfInfected -= temp;
                        country.GetComponent<Country>().numberOfVaccinated += temp;
                        numOfVaccines -= temp;
                    }
                    else if (temp >= country.GetComponent<Country>().numberOfInfected && temp <= country.GetComponent<Country>().numberOfInfected + country.GetComponent<Country>().numberOfHealthy)
                    {
                        int a = temp - country.GetComponent<Country>().numberOfInfected;
                        country.GetComponent<Country>().numberOfVaccinated += temp;
                        country.GetComponent<Country>().numberOfInfected = 0;
                        country.GetComponent<Country>().numberOfHealthy -= a;
                        numOfVaccines -= temp;
                    }
                    else if(temp > country.GetComponent<Country>().numberOfInfected + country.GetComponent<Country>().numberOfHealthy)
                    {
                        numOfVaccines -= country.GetComponent<Country>().numberOfHealthy + country.GetComponent<Country>().numberOfInfected;
                        country.GetComponent<Country>().numberOfInfected = 0;
                        country.GetComponent<Country>().numberOfHealthy = 0;
                        country.GetComponent<Country>().numberOfVaccinated = country.GetComponent<Country>().populationTotal - country.GetComponent<Country>().numberOfDeah;
                    }
                }
                gameObject.GetComponent<UIController>().SetUI(country.GetComponent<Country>().worldName, country.GetComponent<Country>().populationTotal, country.GetComponent<Country>().numberOfHealthy, country.GetComponent<Country>().numberOfInfected, country.GetComponent<Country>().numberOfDeah, country.GetComponent<Country>().numberOfVaccinated);
                gameObject.GetComponent<UIController>().SetMoneyAndVaccines(totalFunds, numOfVaccines);
            }
        }
    }
}
