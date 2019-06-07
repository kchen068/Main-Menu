using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadMenuSceneOnClick : MonoBehaviour
{
    AudioSource[] sauce;
    public GameObject music;

    private void Start()
    {
        //sauce = music.GetComponents<AudioSource>();
        //sauce[0].enabled = false;
    }
    public void LoadByIndex(int sceneIndex)
    {
        //sauce[0].enabled = true;
        //sauce[1].enabled = false;
        //Debug.Log("I AM HEREY7234G2Y323G");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(sceneIndex);
    }
}
