using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioMixer mixer;

    private void Start()
    {   
        //Set mixers floats to last saved players prefs on start of the game
        mixer.SetFloat("Master", Mathf.Log10(PlayerPrefs.GetFloat("Master")) * 20);
        mixer.SetFloat("SFX", Mathf.Log10(PlayerPrefs.GetFloat("SFX")) * 20);
        mixer.SetFloat("Music", Mathf.Log10(PlayerPrefs.GetFloat("Music")) * 20);
    }

    //Changes main audio volume
    public void changeMain(float sliderValue)
    {
        PlayerPrefs.SetFloat("Master", sliderValue);
        mixer.SetFloat("Master", Mathf.Log10(sliderValue) * 20);
    }

    //Changes SFX audio volume
    public void changeSFX(float sliderValue)
    {
        PlayerPrefs.SetFloat("SFX", sliderValue);
        mixer.SetFloat("SFX", Mathf.Log10(sliderValue) * 20);
    }

    //Changes Music audio volume
    public void changeMusic(float sliderValue)
    {
        PlayerPrefs.SetFloat("Music", sliderValue);
        mixer.SetFloat("Music", Mathf.Log10(sliderValue) * 20);
    }
}
