using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public Slider slider;
    public string type;
    public SoundManager sm;

    public bool master, music, sfx;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat(type);

        if (master)
        {
            sm.changeMain(slider.value);
        }

        if (music)
        {
            sm.changeMusic(slider.value);
        }

        if (sfx)
        {
            sm.changeSFX(slider.value);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
