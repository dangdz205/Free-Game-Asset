using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FillStatus : MonoBehaviour
{
    public HEALTH_BAR health_bar;
    public Image fillImage;
    Slider slider;
    private void Awake()
    {
        slider = GetComponent<Slider>();
    }
    private void Update()
    {
        if(slider.value <= slider.minValue)
        {
            fillImage.enabled = false;
        }
        if (slider.value > slider.minValue && !fillImage.enabled)
        {
            fillImage.enabled = true;
        }
        float fillValue = health_bar.currentHealth / health_bar.healthMax;
        if (fillValue <= slider.maxValue / 3)
        {
            fillImage.color = Color.white;
        }
        else if(fillValue > slider.maxValue / 3)
        {
            fillImage.color = Color.red;
        }
            fillValue = slider.value;


    }
}
