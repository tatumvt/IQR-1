using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LazerBar : MonoBehaviour
{
    public int status;
    public int numberOfStatus;
    private float timeRecharge = 0.16f;
    private float timeTake = 0.3f;

    public bool overUse;

    public float visualValue;
    public Image value;

    public PayerSpriteManager psm;

    public Toggle button;
    public PlayerScript pm;

    public AudioSource source;
    public AudioClip on;
    public AudioClip off;

    private void Start()
    {
        StartCoroutine(updateLoop());
    }

    public IEnumerator updateLoop()
    {
        if (pm.weaponParticle.gameObject.activeSelf && !overUse)
        {
            if (source.clip != on)
            {
                source.clip = on;
                source.Play();
            }
            status--;
            psm.updatePlayer(status);
            yield return new WaitForSeconds(timeTake);
            StartCoroutine(updateLoop());
        }
        else
        {
            if (status < numberOfStatus)
            {
                if (source.clip != off)
                {
                    source.clip = off;
                    source.Play();
                }
                status++;
                psm.updatePlayer(status);
                yield return new WaitForSeconds(timeRecharge);
                StartCoroutine(updateLoop());
            }
            else
            {
                yield return new WaitForSeconds(0.01f);
                StartCoroutine(updateLoop());
            }
        }
    }


    private void Update()
    {
        if(overUse == true)
        {
            button.isOn = false;
        }
        if (status <= 0)
        {
            overUse = true;
            button.isOn = false;
            pm.SetWeapon(false);
        }
        if(status == numberOfStatus)
        {
            overUse = false;
        }

        if(status > numberOfStatus)
        {
            status = numberOfStatus;
        }

        visualValue = (float)((decimal)status /(decimal)numberOfStatus);
        value.fillAmount = visualValue;
    }
}
