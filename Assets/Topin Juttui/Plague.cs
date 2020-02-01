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
    float airborneMutationChance;


    private void Mutate()
    {
        float chanceRoll = Random.Range(0.0f, 100.0f);

        if (airborneMutationChance >= chanceRoll & airborne == false)
        {
            airborne = true;
            Debug.Log("Airborne mutation");
            outsideChance += 0.5f;
        }

        else if (chanceRoll > 90f)
        {
            Debug.Log("suuri mutattio ");

            outsideChance += 0.25f;
            insideChance += 0.35f;
        }


        else if (chanceRoll > 65f)
        {
            outsideChance += 0.1f;
            insideChance += 0.15f;

            Debug.Log("Pieni mutattio ");
        }
    }



}
