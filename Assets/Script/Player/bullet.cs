using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private float bulletSpeed = 3f;
    private Transform instantiateTransform;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        float angle = instantiateTransform.rotation.z;
        Vector2 power = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;
        Debug.Log(angle);
        Debug.Log(power);
        rigidBody.AddForce(power * bulletSpeed, ForceMode2D.Impulse);
    }

    void FixedUpdate()
    {
        float angle = Mathf.Atan2(rigidBody.velocity.y, rigidBody.velocity.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0f, 0f, angle);
    }


    public void Set(Transform _instantiateTransform, float _bulletSpeed)
    {
        instantiateTransform = _instantiateTransform;
        bulletSpeed = _bulletSpeed;
    }
}
