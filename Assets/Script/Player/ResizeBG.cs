using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeBG : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ResizeSpriteToScreen();
    }

    void ResizeSpriteToScreen()
    {
        SpriteRenderer sr = this.GetComponent<SpriteRenderer>();
        
        this.transform.localScale = new Vector3(1, 1, 1);

        var width = sr.sprite.bounds.size.x;
        var height = sr.sprite.bounds.size.y;

        var worldScreenHeight = Camera.main.orthographicSize * 2.0;
        var worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        float x = (float)worldScreenWidth / width;
        float y = (float)worldScreenHeight / height;

        sr.transform.localScale = new Vector3(x, y);
    }
}
