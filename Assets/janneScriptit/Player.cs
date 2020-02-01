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

    public GameObject[] countries;

    void Start()
    {
        countries = GameObject.FindGameObjectsWithTag("Country");

        InvokeRepeating("AddFunds", 10f, 2f);
        InvokeRepeating("SendVaccines", 0f, 5f);

        GameObject.Find("GameController").GetComponent<Plague>();
    }

    void Update()
    {
        //call SendVacines() function after certain condition has been met, and repeat every 5 seconds
        if (readyToSentVaccines == true)
            InvokeRepeating("SendVaccines", 0f, 5f);

        GameObject.Find("GameController").GetComponent<UIController>().SetMoneyAndVaccines(totalFunds, numOfVaccines);
    }

    void AddFunds()
    {
        totalFunds += 2 * (passiveIncome);
    }

    public void VaccineLevel1()
    {
        if (totalFunds >= 500)
        {
            totalFunds -= 500;
            if (gameObject.GetComponent<Vaccine>().effectivity == 0)
            {
                gameObject.GetComponent<Vaccine>().effectivity = 1;
                readyToSentVaccines = true;
            }
        }
    }

    public void VaccineLevel2()
    {
        if (totalFunds >= 2000)
        {
            totalFunds -= 2000;
            if (gameObject.GetComponent<Vaccine>().effectivity == 1)
                gameObject.GetComponent<Vaccine>().effectivity = 2;
        }
    }

    public void VaccineLevel3()
    {
        if (totalFunds >= 10000)
        {
            totalFunds -= 10000;
            if (gameObject.GetComponent<Vaccine>().effectivity == 2)
                gameObject.GetComponent<Vaccine>().effectivity = 3;
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

    void SendVaccines()
    {
        foreach(GameObject country in countries)
        {
            float temp = country.GetComponent<Country>().sentVaccinessPerSent;

            if (temp >= numOfVaccines)
                numOfVaccines -= temp;
        }
    }
}
