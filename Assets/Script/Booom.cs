using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booom : MonoBehaviour
{
    public GameObject explosionAreaGO;

    private void Start()
    {
        explosionAreaGO.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.transform.CompareTag("Ground") ||
            collision.transform.CompareTag("Player")) return;

        explosionAreaGO.SetActive(true);
    }
}
