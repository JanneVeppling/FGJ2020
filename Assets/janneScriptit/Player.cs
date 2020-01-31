using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public int numOfInfectedCountries;
    public int numOfHumans;
    public int numOfInfected;
    public int numOfDead;
    public int numOfVaccinated;
    public int totalFunds;
    public int passiveIncome;
    public int sponsMoneyPerSec;
    public int vaccinesPerSec;
    public bool readyToSentVaccines;

    string worldName = "World";
    public TextMeshProUGUI Place;
    public TextMeshProUGUI vac;
    public TextMeshProUGUI dead;
    public TextMeshProUGUI sick;
    public TextMeshProUGUI noVac;

    void Start()
    {

        InvokeRepeating("AddFunds", 10f, 2f);
    }

    void Update()
    {
        //call SendVacines() function after certain condition has been met, and repeat every 5 seconds
        if (readyToSentVaccines == true)
            InvokeRepeating("SendVaccines", 0f, 5f);
        SetUI();
    }

    void AddFunds()
    {
        totalFunds += 2 * (passiveIncome + sponsMoneyPerSec);
    }

    public void SendVaccines()
    {

    }

    public void SetUI()
    {
        int temp;


        temp = numOfHumans - (numOfDead + numOfInfected + numOfVaccinated);
        noVac.text = temp.ToString();
        dead.text = numOfDead.ToString();
        sick.text = numOfInfected.ToString();
        vac.text = numOfVaccinated.ToString();
    }
}
