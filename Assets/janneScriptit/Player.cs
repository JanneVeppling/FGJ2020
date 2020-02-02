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

    public GameObject[] countries;

    void Start()
    {
        countries = GameObject.FindGameObjectsWithTag("Country");

        InvokeRepeating("AddFundsAndVaccines", 10f, 2f);

        GameObject.Find("GameController").GetComponent<Plague>();
    }

    void Update()
    {
        //call SendVacines() function after certain condition has been met, and repeat every 5 seconds
        if (readyToSentVaccines == true)
            InvokeRepeating("SendVaccines", 0f, 5f);

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
            vaccinesPerSec = 10000;
            readyToSentVaccines = true;
        }
    }

    public void VaccineLevel2()
    {
        if (totalFunds >= 2000)
        {
            totalFunds -= 2000;
            vaccinesPerSec = 50000;
        }
    }

    public void VaccineLevel3()
    {
        if (totalFunds >= 10000)
        {
            totalFunds -= 10000;
            vaccinesPerSec = 100000;
        }
    }

    public void MoneyLevel1()
    {
        if (totalFunds >= 500)
        {
            totalFunds -= 500;
            if (passiveIncome == 1)
                passiveIncome++;
        }
    }

    public void MoneyLevel2()
    {
        if (totalFunds >= 2000)
        {
            totalFunds -= 2000;
            if (passiveIncome == 2)
                passiveIncome++;
        }
    }

    public void MoneyLevel3()
    { 
        if (totalFunds >= 10000)
        {
            totalFunds -= 10000;
            if (passiveIncome == 3)
                passiveIncome++;
        }
    }

    public void InformationLevel1()
    {
        if (totalFunds >= 500)
        {
            totalFunds -= 500;
        }
    }

    public void InformationLevel2()
    {
        if(totalFunds >= 2000)
        {
            totalFunds -= 2000;
        }
    }

    public void InformationLevel3()
    {
        if(totalFunds >= 10000)
        {
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

                Debug.Log(temp);

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
                    }
                    else if(temp > country.GetComponent<Country>().numberOfInfected + country.GetComponent<Country>().numberOfHealthy)
                    {
                        country.GetComponent<Country>().numberOfInfected = 0;
                        country.GetComponent<Country>().numberOfHealthy = 0;
                        numOfVaccines -= country.GetComponent<Country>().populationTotal - country.GetComponent<Country>().numberOfDeah;
                        country.GetComponent<Country>().numberOfVaccinated = country.GetComponent<Country>().populationTotal - country.GetComponent<Country>().numberOfDeah;
                    }
                }
                gameObject.GetComponent<UIController>().SetUI(country.GetComponent<Country>().worldName, country.GetComponent<Country>().populationTotal, country.GetComponent<Country>().numberOfHealthy, country.GetComponent<Country>().numberOfInfected, country.GetComponent<Country>().numberOfDeah, country.GetComponent<Country>().numberOfVaccinated);
            }
        }
    }
}
