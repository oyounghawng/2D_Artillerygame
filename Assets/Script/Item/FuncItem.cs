using System;
using Unity.VisualScripting;
using UnityEngine;
public interface IUseFuncItems
{
    public void UseItem(int ItemFunctionIdx);
}
public class FuncItem : MonoBehaviour
{
    protected int itemIdx;
    protected PlayerStats player;
    protected Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public virtual void TakeDamage(int damageAmount)
    {
        Debug.Log("Use Item");
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // 아이템이 액션으로 들어감 ==> ? 해당 아이템이 발동하는 함수, 함수명을 다 똑같이하면 될듯?
            player = other.gameObject.GetComponent<PlayerStats>();
            Managers.Item.UseFuncItem.Add(ItemFunction);
            animator.SetTrigger("Get");
            //Managers.Item.UseItem(0); 임시
            Invoke("DestroyItem", 1f);


        }
    }
    public virtual void ItemFunction()
    {
        // animation on
        //player.TransDamage(Managers.Data.items[itemIdx].value);
        Debug.Log("use");
    }
    private void DestroyItem()
    {
        Destroy(gameObject);
    }
}