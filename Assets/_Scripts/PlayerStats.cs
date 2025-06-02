using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Slider boostSlider;

    public void SetMaxBoost(float boost)
    {
        boostSlider.maxValue = boost;
        boostSlider.value = boost;
    }

    public void SetBoost(float boost)
    {
        boostSlider.value = boost;
    }
}
