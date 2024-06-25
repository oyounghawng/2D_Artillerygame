using Photon.Pun;
using UnityEngine;

public class Bullet : MonoBehaviourPunCallbacks
{
    private Rigidbody2D rigidBody;
    private float bulletSpeed;
    private Transform instantiateTransform;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        if (instantiateTransform == null)
        {
            Debug.LogError("instantiateTransform is not assigned in Bullet.");
            return;
        }

        bulletSpeed *= 1.5f;
        float angle = instantiateTransform.eulerAngles.z * Mathf.Deg2Rad;
        Vector2 power = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;
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
