using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderVolume : MonoBehaviour
{
    public Slider Volume;
    public AudioSource sauce;
    //public AudioSource sauce2;

    void Update ()
    {
        sauce.volume = Volume.value;
        //sauce2.volume = Volume.value;
    }
}
