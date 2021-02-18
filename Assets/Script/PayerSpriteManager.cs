using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayerSpriteManager : MonoBehaviour
{
    [SerializeField]
    private Sprite[] Images = null;
    [SerializeField]
    private LazerBar LB = null;

    private SpriteRenderer sr;

    private void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
        sr.sprite = Images[LB.Status - 1];
    }

    public void updatePlayer(int state)
    {
        if (state != 0)
        {
            sr.sprite = Images[state - 1];
        }
    }
}
