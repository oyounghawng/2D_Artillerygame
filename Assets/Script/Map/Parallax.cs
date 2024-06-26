using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Parallax : MonoBehaviour
{

    public float[] scrollSpeeds;
    public Transform[] childObject;
    public float screenWidth;

    private void Awake()
    {
        int childCount = transform.childCount;
        childObject = new Transform[childCount];

        for (int i = 0; i < childObject.Length; i++)
        {
            childObject[i] = gameObject.transform.GetChild(i);
        }
    }

    private void Update()
    {
        ParallaxScroll();
    }

    private void ParallaxScroll()
    {

        for (int i = 0; i < childObject.Length; i++)
        {
            Vector3 newPosition = childObject[i].position;
            newPosition.x -= scrollSpeeds[i] * Time.deltaTime;
            childObject[i].position = newPosition;

            if (childObject[i].position.x <= -screenWidth)
            {
                newPosition.x = screenWidth + (childObject[i].position.x + screenWidth);
                childObject[i].position = newPosition;
            }
        }

    }
    



}
