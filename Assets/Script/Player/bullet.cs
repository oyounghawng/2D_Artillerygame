using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private float bulletSpeed;
    private Transform instantiateTransform;
    private TurnManager turnManager;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        turnManager = TurnManager.instance;
    }

    void Start()
    {
        bulletSpeed *= 1.5f;
        float angle = instantiateTransform.eulerAngles.z * Mathf.Deg2Rad;
        Vector2 power = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;

        float windAngleRad = turnManager.windDirection * Mathf.Deg2Rad;
        Vector2 windPower = new Vector2(Mathf.Cos(windAngleRad), Mathf.Sin(windAngleRad)) * turnManager.windPower;
        Vector2 totalPower = (power * bulletSpeed) + windPower;
        rigidBody.AddForce(totalPower, ForceMode2D.Impulse);

        StartCoroutine(ObjectClear());
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

    IEnumerator ObjectClear()
    {
        yield return new WaitForSeconds(5);
        if (-30 > gameObject.transform.position.y)
        {
            Debug.Log(name);
            Destroy(gameObject);
        }
    }
}
