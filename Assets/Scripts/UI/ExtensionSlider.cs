using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class ExtensionSlider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Slider slider = GetComponent<Slider>();
        slider.onValueChanged.Invoke(slider.value);
    }
}
