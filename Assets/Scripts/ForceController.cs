using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ForceController : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI textValue;

    private int _value;
    public int force => _value;

    public void Start()
    {
        _value = (int)slider.value;
    }

    public void OnValueChanged(Single value)
    {
        _value = (int)(value * 100f);
        textValue.text = _value.ToString();
    }
}
