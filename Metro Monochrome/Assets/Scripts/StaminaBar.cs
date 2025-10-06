using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider slider;

    // Set the max value of the slider 
    public void SetMaxValue(int amount)
    {
        slider.maxValue = amount;
        slider.value = amount; // sets the current value to the maxValue
    }

    public void SetValue(int amount)
    {
        slider.value = amount;
    }

    public void ManipulateMaxValue(int amount)
    {
        slider.maxValue = amount;
    }
}
