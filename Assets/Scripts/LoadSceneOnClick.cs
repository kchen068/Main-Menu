using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadSceneOnClick : MonoBehaviour
{
    AudioSource[] sauce;
    public GameObject music;

    private void Start()
    {
        //sauce = music.GetComponents<AudioSource>();
        //sauce[1].enabled = false;
    }
    public void LoadByIndex(int sceneIndex)
    {
        //sauce[1].enabled = true;
        //sauce[0].enabled = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(sceneIndex);
    }
}
