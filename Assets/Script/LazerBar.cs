using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LazerBar : MonoBehaviour
{
    public int Status;
    public int NumberOfStatus;
    public Image Percentage;

    //public Image[] bars;
    //public Sprite Fullbar;
    //public Sprite Emptybar;

    public float TimeRecharge = 0.1f;
    public float TimeTake = 0.1f;

    public float test;

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
            Status--;
            psm.updatePlayer(Status);
            yield return new WaitForSeconds(TimeTake);
            StartCoroutine(updateLoop());
        }
        else
        {
            if (Status < NumberOfStatus)
            {
                Status++;
                psm.updatePlayer(Status);
                yield return new WaitForSeconds(TimeRecharge);
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
        if (Status <= 0)
        {
            button.isOn = false;
            pm.SetWeapon(false);
        }

        if(Status > NumberOfStatus)
        {
            Status = NumberOfStatus;
        }

        test = (float)((decimal)Status /(decimal)NumberOfStatus);
        Percentage.fillAmount = test;
    }
}
