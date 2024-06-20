using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    public float bulletSpeed ;
 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(PlayerAttack.Gunangle.transform.right * bulletSpeed);
    }
    
    void FixedUpdate()
    { 
        float angle=Mathf.Atan2(rb.velocity.y, rb.velocity.x)*Mathf.Rad2Deg;
        transform.eulerAngles= new Vector3 (0f, 0f, angle);
    }
}
