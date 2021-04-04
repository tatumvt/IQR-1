using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckScore : MonoBehaviour
{
    public string highScoreToCheck;
    public int highscoreToGet;

    public TextMeshProUGUI text;
    public Image slotje;

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt(highScoreToCheck) >= highscoreToGet)
        {
            slotje.gameObject.SetActive(false);
            text.gameObject.SetActive(true);
            this.GetComponent<Button>().enabled = true;
        }
        else
        {
            slotje.gameObject.SetActive(true);
            text.gameObject.SetActive(false);
            this.GetComponent<Button>().enabled = false;
        }
    }
}
