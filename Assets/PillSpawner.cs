using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    private BoxCollider2D bc;
    private SpriteRenderer render;
    public bool pickedUp = false;
    public int minWait;
    public int maxWait;
    public int random;

    void Start()
    {
        bc = this.GetComponent<BoxCollider2D>();
        render = this.GetComponentInChildren<SpriteRenderer>();

        bc.enabled = true;
        render.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (pickedUp)
        {
            pickedUp = false;
            bc.enabled = false;
            render.enabled = false;
            random = Random.Range(minWait, maxWait);
            StartCoroutine(reactivate(random));
        }
    }

    IEnumerator reactivate(int r)
    {
        yield return new WaitForSeconds(r);
        render.enabled = true;
        bc.enabled = true;
    }
}
