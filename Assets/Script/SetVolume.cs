using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    //Chosen slider
    public Slider slider;
    //Mixer name
    public string mixerTypeName;
    //Sound manager
    public SoundManager sm;

    public bool master, music, sfx;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat(mixerTypeName);

        //Check what bool is active so it knows what to change
        if (master)
        {
            sm.changeMain(slider.value);
        }else
        if (music)
        {
            sm.changeMusic(slider.value);
        }else
        if (sfx)
        {
            sm.changeSFX(slider.value);
        }
    }
}
