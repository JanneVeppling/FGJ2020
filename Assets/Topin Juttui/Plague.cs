using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plague : MonoBehaviour
{
    
    public float outsideChance = 0.6f;
    public float insideChance = 0.8f;
    public float deathchance =0;
    float mutationAcceleration;

    float informationMultiplier;

    public void Mutate()
    {
        float chanceRoll = Random.Range(0.0f, 100.0f);

        chanceRoll += (mutationAcceleration);

      

         if (chanceRoll > 90.0f)
        {
            //Debug.Log("suuri mutaatio ");

            outsideChance += 0.05f;
            insideChance += 0.05f;

            deathchance += 0.0004f;
            mutationAcceleration += 0.02f;
         

        }


        else if (chanceRoll > 65.0f)
        {
            outsideChance += 0.01f;
            insideChance += 0.02f;
           // mutationAcceleration += 0.5f;
            //deathchance += 0.005f;

          //  Debug.Log("Pieni mutaatio ");
        }
    }

}
