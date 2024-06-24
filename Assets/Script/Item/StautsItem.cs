using System.Collections.Generic;
using UnityEngine;

public class StautsItem : MonoBehaviour
{
    protected Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public virtual void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("Get");
            Invoke("DestroyItem", 1f);
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