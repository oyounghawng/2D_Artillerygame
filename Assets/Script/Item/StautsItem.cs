using System.Collections.Generic;
using UnityEngine;

public class StautsItem : MonoBehaviour
{
    protected TestPlayer testPlayer;
    protected Animator animator;
    void Start()
    {
        testPlayer = GetComponent<TestPlayer>();
        animator = GetComponent<Animator>();
    }

    public virtual void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Use Item");
            animator.SetTrigger("Get");
            Invoke("DestroyItem", 0.3f);
        }
        else if (other.gameObject.CompareTag("EndLine"))
        {
            DestroyItem();
        }
    }

    private void DestroyItem()
    {
        Destroy(gameObject);
    }
}