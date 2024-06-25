using Photon.Pun;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviourPunCallbacks
{
    private Rigidbody2D rigidBody;
    private float bulletSpeed;
    private TurnManager turnManager;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        turnManager = TurnManager.instance;
    }

    [PunRPC]
    private void RPC_Start(float _angle, float _bulletSpeed)
    {
        bulletSpeed = _bulletSpeed;
        bulletSpeed *= 1.5f;

        float angle = _angle * Mathf.Deg2Rad;
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
