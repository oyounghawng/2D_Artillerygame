using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booom : MonoBehaviour
{
    public GameObject explosionAreaGO;

    private void Start()
    {
        explosionAreaGO.SetActive(false);
        explosionAreaGO.GetComponent<CircleCollider2D>().radius
            += (GetComponent<Bullet>().damage - 1) * 0.1f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag(Tags.Player) || collision.transform.CompareTag(Tags.Ground))
        {
            explosionAreaGO.SetActive(true);
            Destroy(gameObject, 0.02f);
            return;
        }
    }
}
