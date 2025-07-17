using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadScene1 : MonoBehaviour
{
    
    public void loadSceneMain()
    {
        SceneManager.LoadScene(1);
        Debug.Log("load");
        
    }
    public Slider volumeSlider;
    public AudioMixer mixer;
    public void SetVolume()
    {
        mixer.SetFloat("volume", volumeSlider.value);

    }
}
