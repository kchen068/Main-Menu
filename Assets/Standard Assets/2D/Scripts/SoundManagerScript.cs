using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioClip a1, a2, a3, a4, a5;
    public static AudioSource audioSource;
    void Start()
    {
        a1 = Resources.Load<AudioClip>("gunshot");
        a2 = Resources.Load<AudioClip>("jump");
        a3 = Resources.Load<AudioClip>("throw");
        a4 = Resources.Load<AudioClip>("throw2");
        a5 = Resources.Load<AudioClip>("thud");
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void playSound(string type)
    {
        if (type == "gunshot")
        {
            audioSource.PlayOneShot(a1);
        }
        else if (type == "jump")
        {
            audioSource.PlayOneShot(a2);
        }
        else if (type == "throw")
        {
            audioSource.PlayOneShot(a3);
        }
        else if (type == "throw2")
        {
            audioSource.PlayOneShot(a4);
        }
        else if (type == "thud")
        {
            audioSource.PlayOneShot(a5);
        }
    }
}
