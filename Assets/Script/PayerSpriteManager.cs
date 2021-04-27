using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayerSpriteManager : MonoBehaviour
{
    [SerializeField]
    private Sprite[] images = null;
    [SerializeField]
    private LazerBar LB = null;

    private SpriteRenderer sr;

    private void Start()
    {
        //Sets first sprite
        sr = this.GetComponent<SpriteRenderer>();
        sr.sprite = images[LB.status - 1];
    }

    public void updatePlayer(int state)
    {
        //if the state is not zero it will change the sprite to the lazerbar value - 1 for the array
        //This will change the hair of the player if it uses the beam.
        if (state != 0)
        {
            sr.sprite = images[state - 1];
        }
    }
}
