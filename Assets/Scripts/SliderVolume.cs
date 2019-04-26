using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderVolume : MonoBehaviour
{
    public Slider Volume;
    public AudioSource sauce;

    void Update ()
    {
        sauce.volume = Volume.value;
    }
}
