using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Change the 'color' property of the 'Sprite Renderer'
            sprite.color = new Color(1, 0, 0, 1);
        }
    }
}