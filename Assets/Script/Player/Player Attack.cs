using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public float Angle;//각도
    public float gunbarrelSpeed;//포신의 속도
    public GameObject gunbarrel; //포신 //Shooting Arrow
    public GameObject bullet; //포탄
    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Angle = Angle + Time.deltaTime * gunbarrelSpeed;
            float rad = Angle * Mathf.Deg2Rad;
            gunbarrel.transform.localPosition = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
            gunbarrel.transform.eulerAngles = new Vector3(0,0, Angle); 
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
                Angle = Angle - Time.deltaTime * gunbarrelSpeed;
            float rad = Angle * Mathf.Deg2Rad;
            gunbarrel.transform.localPosition = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
            gunbarrel.transform.eulerAngles = new Vector3(0,0, Angle);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject go= Instantiate(bullet);
            go.transform.localPosition = gunbarrel.transform.position;
        }


    }
}
