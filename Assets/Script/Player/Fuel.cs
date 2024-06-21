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
        if (fuel <= 0) // 체력이 0 이하면
        {
            return; // 움직임을 멈춤
        }

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) // 플레이어가 움직이면
        {
            Decreasefuel(decreaseAmount); // 체력 감소
        }
    }


    public void Decreasefuel(float amount)
    {
        fuel -= amount;
        slider.value = fuel;
    }
}
