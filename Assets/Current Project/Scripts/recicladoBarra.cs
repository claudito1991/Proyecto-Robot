using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class recicladoBarra : MonoBehaviour
{
    public Slider slider;

    public void SetMaxReciclado (float reciclado)
    {
        slider.maxValue = reciclado;
        
    }

    public void SetReciclado (float reciclado)
    {
        slider.value = reciclado;
    }


}
