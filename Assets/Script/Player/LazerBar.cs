using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LazerBar : MonoBehaviour
{
    public int status;
    public int numberOfStatus;
    public float timeRecharge = 0.1f;
    public float timeTake = 0.1f;

    public float visualValue;
    public Image value;

    public PayerSpriteManager psm;

    public Toggle button;
    public PlayerScript pm;

    private void Start()
    {
        StartCoroutine(updateLoop());
    }

    public IEnumerator updateLoop()
    {
        if (pm.weaponParticle.gameObject.activeSelf)
        {
            status--;
            psm.updatePlayer(status);
            yield return new WaitForSeconds(timeTake);
            StartCoroutine(updateLoop());
        }
        else
        {
            if (status < numberOfStatus)
            {
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
        if (status <= 0)
        {
            button.isOn = false;
            pm.SetWeapon(false);
        }

        if(status > numberOfStatus)
        {
            status = numberOfStatus;
        }

        visualValue = (float)((decimal)status /(decimal)numberOfStatus);
        value.fillAmount = visualValue;
    }
}
