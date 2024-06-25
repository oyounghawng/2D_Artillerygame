using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour
{
    public Slider slider;
    public float fuel;
    public readonly float maxFuel = 1000;
    public float fuelRechargeRate = 1f;
    public void ResetFuel()
    {
        fuel = maxFuel;
        slider.value = fuel / maxFuel;
    }
    public bool IsEmpty()
    {
        return fuel <= 0;
    }
    public void IncreaseFuel(float amount)
    {
        fuel += amount;
        if (fuel > maxFuel)
        {
            fuel = maxFuel;
        }
        slider.value = fuel / maxFuel;
    }

    public void Decreasefuel(float amount)
    {
        fuel -= amount;
        slider.value = fuel / maxFuel;
    }
}
