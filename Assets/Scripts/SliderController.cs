using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour {

    [SerializeField]
    private IntEvent sliderPositionChanged;

    private Slider slider;
    private float minValue;
    private float maxValue;
    private float actualValue;

    private void Start()
    {
        slider = GetComponent<Slider>();
        minValue = slider.minValue;
        maxValue = slider.maxValue;
    }

    public void OnValueChange()
    {
        actualValue = slider.value;
        int sliderPercentageValue = (int)(actualValue * 100 / maxValue);
        sliderPositionChanged.Invoke(sliderPercentageValue);
    }
}
