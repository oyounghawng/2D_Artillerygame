using System.Collections.Generic;
using UnityEngine;

public interface IUseitem
{
    public void UseItem(Collision2D other);
}

public class StautsItem : MonoBehaviour , IUseitem
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
            UseItem(other);
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

    public virtual void UseItem(Collision2D other)
    {

    }
}