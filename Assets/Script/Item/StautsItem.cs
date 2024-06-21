using System.Collections.Generic;
using UnityEngine;

public class StautsItem : MonoBehaviour
{
    protected TestPlayer testPlayer;
    void Start()
    {
        testPlayer = GetComponent<TestPlayer>();

    }

    public virtual void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            Debug.Log("Use Item");
        }
    }

}