using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryHover : MonoBehaviour
{
    void OnMouseOver()
    {
        Debug.Log("Mouse is over GameObject.");
    }

    void OnMouseExit()
    {
        Debug.Log("Mouse is no longer on GameObject.");
    }
}
