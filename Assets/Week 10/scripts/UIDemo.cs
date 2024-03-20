using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIDemo : MonoBehaviour
{
    public SpriteRenderer sr;
    public Color start;
    public Color end;
    float interpolation;

    public TMP_Dropdown dropdown;

    public void SliderValueHasChanged(float value)
    {
        interpolation = value;

    }

    public void DropdownSelectionHasChanged(int value)
    {
        Debug.Log(dropdown.options[value].text);
    }

    private void Update()
    {
        sr.color = Color.Lerp(start, end, (interpolation/60));
    }
}
