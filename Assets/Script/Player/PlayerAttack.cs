using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public bool myturn = false;

    public float Angle;//����
    public float gunbarrelSpeed;//������ �ӵ�
    public GameObject gunbarrel; //���� //Shooting Arrow
    public GameObject bullet; //��ź

    public static GameObject Gunangle;

    void Start()
    {
        Gunangle = gunbarrel;
    }


    void Update()
    {
        if (!myturn)
            return;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Angle = Angle + Time.deltaTime * gunbarrelSpeed;
            float rad = Angle * Mathf.Deg2Rad;
            gunbarrel.transform.localPosition = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
            gunbarrel.transform.eulerAngles = new Vector3(0, 0, Angle);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Angle = Angle - Time.deltaTime * gunbarrelSpeed;
            float rad = Angle * Mathf.Deg2Rad;
            gunbarrel.transform.localPosition = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
            gunbarrel.transform.eulerAngles = new Vector3(0, 0, Angle);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            GameObject go = Instantiate(bullet);
            go.transform.localPosition = gunbarrel.transform.position;
            TurnManager.instance.ChangeTurn();
        }
    }
}
