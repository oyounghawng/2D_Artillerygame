using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Vector3 mousePosition;
    public LayerMask whatIsGround;
    public GameObject booomClone;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
            mousePosition.z = 0;
            Instantiate(booomClone, mousePosition, Quaternion.identity);
        }
    }

}
