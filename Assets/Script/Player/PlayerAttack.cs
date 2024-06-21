using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float Angle;//각도
    public float gunbarrelSpeed;//포신의 속도
    public GameObject bullet; //포탄

    private Vector2 movementDirection;
    private Controller controller;

    private GameObject gunbarrel; //포신 //Shooting Arrow

    private void Awake()
    {
        controller = GetComponentInParent<Controller>();
        gunbarrel = Util.FindChild(this.gameObject, "Shooting", true);
    }
    void Start()
    {
        controller.OnAimEvent += Aim;
        controller.OnFireEvent += Fire;
    }

    private void FixedUpdate()
    {
        Angle = Angle + Time.deltaTime * gunbarrelSpeed * movementDirection.y;
        float rad = Angle * Mathf.Deg2Rad;
        gunbarrel.transform.localPosition = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
        gunbarrel.transform.eulerAngles = new Vector3(0, 0, Angle);
    }

    private void Aim(Vector2 value)
    {
        movementDirection = value;
    }

    private void Fire(float value)
    {
        GameObject go = Instantiate(bullet);
        go.GetComponent<Bullet>().Set(this.transform);
        go.transform.localPosition = gunbarrel.transform.position;
        TurnManager.instance.ChangeTurn();
    }
}
