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
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;

            Collider2D overCollider2d = Physics2D.OverlapCircle (mousePosition, 0.01f, whatIsGround);
            if (overCollider2d != null)
            {
                overCollider2d.transform.GetComponent<Square>().MakeDot(mousePosition);
            }
        }

        else if (Input.GetMouseButtonDown(1))
        {
            mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
            mousePosition.z = 0;
            Instantiate(booomClone, mousePosition, Quaternion.identity);
        }
    }

}
