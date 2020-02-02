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

    public GameObject[] countries;

    private bool UMenu;

    // Start is called before the first frame update
    void Start()
    {
        countries = GameObject.FindGameObjectsWithTag("Country");
        InvokeRepeating("RefreshUI", 1f, 1f);
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

    public void RefreshUI()
    {
        if (gameObject.GetComponent<Player>().currentSelecetedWorld == 0)
        {
            GameObject.Find("World").GetComponent<World>().GetWorldStats();
            SetUI(GameObject.Find("World").GetComponent<World>().worldName, GameObject.Find("World").GetComponent<World>().population, GameObject.Find("World").GetComponent<World>().healthy, GameObject.Find("World").GetComponent<World>().infected, GameObject.Find("World").GetComponent<World>().dead, GameObject.Find("World").GetComponent<World>().vaccinated);
        }
        else
        {
            foreach (GameObject country in countries)
            {
                if (country.GetComponent<Country>().id == gameObject.GetComponent<Player>().currentSelecetedWorld)
                {
                    SetUI(country.GetComponent<Country>().worldName, country.GetComponent<Country>().populationTotal, country.GetComponent<Country>().numberOfHealthy, country.GetComponent<Country>().numberOfInfected, country.GetComponent<Country>().numberOfDeah, country.GetComponent<Country>().numberOfVaccinated);
                }
            }
        }
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
