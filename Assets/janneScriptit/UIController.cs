using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI Place;
    public TextMeshProUGUI vac;
    public TextMeshProUGUI dead;
    public TextMeshProUGUI sick;
    public TextMeshProUGUI noVac;

    public GameObject world;
    public GameObject country1;
    public GameObject country2;

    // Start is called before the first frame update
    void Start()
    {
        //SetUI(1);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1"))
            SetUI(1);
    }


    public void SetUI(int ID)
    {
        /*foreach(Country country in country.countries)
        {
            Debug.Log(country.populationTotal);
        }*/

        //temp = country. numOfHumans - (numOfDead + numOfInfected + numOfVaccinated);
        /*noVac.text = temp.ToString();
        dead.text = numOfDead.ToString();
        sick.text = numOfInfected.ToString();
        vac.text = numOfVaccinated.ToString(); */
    }
}
