using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameEnd : MonoBehaviour
{
    private float targetTime1 = 30.0f;



    void Update()
    {
        targetTime1 -= Time.deltaTime;

        if (targetTime1 <= 0 )
        {

        if (GameObject.Find("World").GetComponent<World>().infected <= 1)
        {
            Debug.Log("Then end is upon us");


                SceneManager.LoadScene(0);

            }

        }


    }
}
