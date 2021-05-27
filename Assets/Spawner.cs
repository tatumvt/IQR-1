using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public TextMeshProUGUI popUps;
    //public GameObject popUpsObject;
    public void Spawn(Vector3 position, string score)
    {
        popUps.text = score;
        TextMeshProUGUI temp = Instantiate(popUps);
        temp.transform.parent = this.transform;
        temp.transform.position = position;
        temp.transform.localScale = new Vector3(1, 1, 1);
    }
}
