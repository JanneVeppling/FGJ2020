using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI Place;
    public TextMeshProUGUI population;
    public TextMeshProUGUI vac;
    public TextMeshProUGUI dead;
    public TextMeshProUGUI sick;
    public TextMeshProUGUI noVac;

    // Start is called before the first frame update
    void Start()
    {
        SetUI(0,0,0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUI(float populationTotal, float numberOfHealthy, float numberOfInfected, float numberOfDeah, float numberOfVaccinated)
    {
        population.text = populationTotal.ToString();
        noVac.text = numberOfHealthy.ToString();
        vac.text = numberOfVaccinated.ToString();
        dead.text = numberOfDeah.ToString();
        sick.text = numberOfInfected.ToString(); 
    }
}
