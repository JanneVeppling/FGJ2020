using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int numOfInfectedCountries;
    public int totalFunds;
    public int passiveIncome;
    public int sponsMoneyPerSec;
    public int vaccinesPerSec;
    public float numOfVaccines;
    public bool readyToSentVaccines;

    public GameObject[] countries;

    void Start()
    {
        countries = GameObject.FindGameObjectsWithTag("Country");

        InvokeRepeating("AddFunds", 10f, 2f);
        InvokeRepeating("SendVaccines", 0f, 5f);
    }

    void Update()
    {
        //call SendVacines() function after certain condition has been met, and repeat every 5 seconds
        if (readyToSentVaccines == true)
            InvokeRepeating("SendVaccines", 0f, 5f);
    }

    void AddFunds()
    {
        totalFunds += 2 * (passiveIncome + sponsMoneyPerSec);
    }

    public void VaccineLevelUpgrade()
    {
        gameObject.GetComponent<Vaccine>().effectivity += 1;
    }

    void SendVaccines()
    {
        foreach(GameObject country in countries)
        {
            float temp = country.GetComponent<Country>().sentVaccinessPerSent;

            if (temp <= numOfVaccines)
                numOfVaccines -= temp;
        }
    }
}
