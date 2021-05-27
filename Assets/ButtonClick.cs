using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] clips;
    static AudioSource Source;
    static AudioClip[] Clips;

    private void Start()
    {
        Source = source;
        Clips = clips;
    }

    public void buttonClick()
    {
        Source.clip = Clips[Random.Range(0, Clips.Length)];
        Source.Play();
    }
}
