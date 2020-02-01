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

        }

        else if (chanceRoll > 90)
        {

            //do seriois mutation stuff
        }


        else if (chanceRoll > 60)
        {

            //do smoll mutation stuff
        }
    }
}
