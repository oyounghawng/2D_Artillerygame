using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour
{
    public Slider slider;
    public float fuel;
    public readonly float maxFuel = 1000;

    void Start()
    {
        fuel = maxFuel;

    }
    public void Decreasefuel(float amount)
    {
        fuel -= amount;
        slider.value = fuel / maxFuel;
    }
}
