using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    public AudioSource source;
    public AudioClip mainMenu;
    public AudioClip levelMenu;
    public GameObject level;
    public bool hasPlayed;

    // Start is called before the first frame update
    void Start()
    {
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (level.activeSelf)
        {

            if (source.clip != levelMenu)
            {
                if (!hasPlayed)
                {
                    source.volume -= 0.022f;
                    if (source.volume == 0)
                    {
                        source.clip = levelMenu;
                        source.Play();
                        source.loop = false;
                    }
                }
            }
            else
            {
                source.volume += 0.022f;
                if(source.isPlaying == false)
                {
                    hasPlayed = true;
                    source.clip = mainMenu;
                    source.volume = 1;
                    source.Play();
                }
            }
        }
        else
        {
            if(source.clip != mainMenu)
            {
                source.clip = mainMenu;
                source.volume = 1;
                source.Play();
            }             
        }
    }
}
