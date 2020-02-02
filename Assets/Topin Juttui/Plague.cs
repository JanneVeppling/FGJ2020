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
    public float deathchance =0;
    float mutationAcceleration;

    float informationMultiplier;

    public void Mutate()
    {
        float chanceRoll = Random.Range(0.0f, 100.0f);

        chanceRoll += (mutationAcceleration);

      

         if (chanceRoll > 90f)
        {
            Debug.Log("suuri mutaatio ");

            outsideChance += 0.05f;
            insideChance += 0.05f;

            deathchance += 0.00005f;
            mutationAcceleration += 0.02f;
         

        }


        else if (chanceRoll > 65f)
        {
            outsideChance += 0.02f;
            insideChance += 0.05f;
           // mutationAcceleration += 0.5f;
            //deathchance += 0.005f;

          //  Debug.Log("Pieni mutaatio ");
        }
    }

}
