using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI Place;
    public TextMeshProUGUI population;
    public TextMeshProUGUI vac;
    public TextMeshProUGUI dead;
    public TextMeshProUGUI sick;
    public TextMeshProUGUI noVac;
    public TextMeshProUGUI vaccines;
    public TextMeshProUGUI money;

    public Text sendInput;

    public GameObject UpgradeMenu;

    private bool UMenu;

    // Start is called before the first frame update
    void Start()
    {
        SetUI("World",0,0,0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("i"))
            UpgradeMenuActivation();
    }

    public void UpgradeMenuActivation()
    {
        if (UMenu)
            UMenu = false;
        else if (!UMenu)
            UMenu = true;

        UpgradeMenu.SetActive(UMenu);
    }

    public void SetUI(string worldName, float populationTotal, float numberOfHealthy, float numberOfInfected, float numberOfDeah, float numberOfVaccinated)
    {
        Place.text = worldName;
        population.text = populationTotal.ToString();
        noVac.text = numberOfHealthy.ToString();
        vac.text = numberOfVaccinated.ToString();
        dead.text = numberOfDeah.ToString();
        sick.text = numberOfInfected.ToString(); 
    }

    public void SetMoneyAndVaccines(int totalMoney, float totalVaccines)
    {
        vaccines.text = totalVaccines.ToString();
        money.text = totalMoney.ToString();
    }
}
