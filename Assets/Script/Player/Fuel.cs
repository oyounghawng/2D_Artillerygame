using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;


public class Fuel : PlayerMovement
{
    public Slider slider;
    public float fuel = 1000;
    public float decreaseAmount = 1;

    void Start()
    {
        slider.maxValue = fuel;
        slider.value = fuel;
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
    //    {
    //        Decreasefuel(decreaseAmount);
    //    }
    //}
    void Update()
    {
        if (fuel <= 0) // ü���� 0 ���ϸ�
        {
            return; // �������� ����
        }

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) // �÷��̾ �����̸�
        {
            Decreasefuel(decreaseAmount); // ü�� ����
        }
    }


    public void Decreasefuel(float amount)
    {
        fuel -= amount;
        slider.value = fuel;
    }
}
