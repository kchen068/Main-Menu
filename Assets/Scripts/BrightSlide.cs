using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrightSlide : MonoBehaviour
{
    public float GammaCorrection;
    //public Rect SliderLocation;
    public Slider bright;

    void Start()
    {
        GammaCorrection = 0.55f;
        RenderSettings.ambientLight = new Color(GammaCorrection, GammaCorrection, GammaCorrection, 1.0f);
    }
    // Update is called once per frame
    void Update()
    {
        GammaCorrection = bright.value;
        RenderSettings.ambientLight = new Color(GammaCorrection, GammaCorrection, GammaCorrection, 1.0f);

    }
}
