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
    public bool readyToSentVaccines;

    void Start()
    {

        InvokeRepeating("AddFunds", 10f, 2f);
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

    public void SendVaccines()
    {

    }
}
