using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plague : MonoBehaviour
{
    public float drugRes;
    float mutationChance;
    public float outsideChance;
    public float insideChance;
    public bool airborne;
    float airborneMutationChance = 2f;
    public float deathchance;
    float mutationAcceleration;

    float informationMultiplier;

    public void Mutate()
    {
        float chanceRoll = Random.Range(0.0f, 100.0f);

        chanceRoll += (mutationAcceleration);

        if (airborneMutationChance >= chanceRoll & airborne == false)
        {
            airborne = true;
            Debug.Log("Airborne mutation");
            outsideChance += 0.5f;         
        }

        else if (chanceRoll > 90f)
        {
            Debug.Log("suuri mutaatio ");

            outsideChance += 0.15f;
            insideChance += 0.15f;

            deathchance += 0.02f;
            mutationAcceleration += 2f;
        }


        else if (chanceRoll > 65f)
        {
            outsideChance += 0.1f;
            insideChance += 0.05f;
            mutationAcceleration += 0.5f;
            deathchance += 0.01f;

            Debug.Log("Pieni mutaatio ");
        }
    }

}
