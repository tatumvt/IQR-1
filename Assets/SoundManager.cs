using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioMixer mixer;

    private void Start()
    {
        mixer.SetFloat("Master", Mathf.Log10(PlayerPrefs.GetFloat("Master")) * 20);
        mixer.SetFloat("SFX", Mathf.Log10(PlayerPrefs.GetFloat("SFX")) * 20);
        mixer.SetFloat("Music", Mathf.Log10(PlayerPrefs.GetFloat("Music")) * 20);
    }

    public void changeMain(float sliderValue)
    {
        PlayerPrefs.SetFloat("Master", sliderValue);
        mixer.SetFloat("Master", Mathf.Log10(sliderValue) * 20);
    }

    public void changeSFX(float sliderValue)
    {
        PlayerPrefs.SetFloat("SFX", sliderValue);
        mixer.SetFloat("SFX", Mathf.Log10(sliderValue) * 20);
    }

    public void changeMusic(float sliderValue)
    {
        PlayerPrefs.SetFloat("Music", sliderValue);
        mixer.SetFloat("Music", Mathf.Log10(sliderValue) * 20);
    }

}
